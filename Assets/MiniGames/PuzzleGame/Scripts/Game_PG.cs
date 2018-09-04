using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_PG : MonoBehaviour
{
    Vector3 screenPositionToAnimate;
    private Piece_PG PieceToAnimate;
    private int toAnimateI, toAnimateJ;
    public GameObject StartPanel;
    public GameObject EndPanel;
    public Piece_PG[,] Matrix;
    public Text TimeText;
    public Text EndText;
    AudioSource dragSound;
    int CR;
    float timer;
    GameObject puzzle;
    private GameState gameState;
    public GameObject[] Puzzles;
    private GameObject[] go;
    public float AnimSpeed = 10f;
    float xSpace, ySpace;
    // Use this for initialization
    void Start()
    {
        dragSound = GetComponent<AudioSource>();
        NewPuzzle(); 
    }
    private void NewPuzzle()
    {
        timer = 0;
        int rdm = UnityEngine.Random.Range(0, Puzzles.Length);
        puzzle = Instantiate(Puzzles[rdm], Puzzles[rdm].transform.position, Puzzles[rdm].transform.rotation);
        go = puzzle.GetComponent<PiecesScript_PG>().pieces;
        xSpace = puzzle.GetComponent<PiecesScript_PG>().xSpace;
        ySpace = puzzle.GetComponent<PiecesScript_PG>().ySpace;
        gameState = GameState.Start;
        CR = (int)Mathf.Sqrt(go.Length);
        Matrix = new Piece_PG[CR, CR];
        //random blank piece
        int index = Random.Range(0, go.Length);
        go[index].SetActive(false);

        //get the objects from the 1D array,
        //convert them to Piece class and
        //place them in a 2D array
        for (int i = 0; i < CR; i++)
        {
            for (int j = 0; j < CR; j++)
            {
                if (go[i * CR + j].activeInHierarchy)
                {
                    Vector3 point = GetScreenCoordinatesFromVieport(i, j);
                    go[i * CR + j].transform.position = point;

                    //place relevant information
                    Matrix[i, j] = new Piece_PG();
                    Matrix[i, j].GameObject = go[i * CR + j];
                    Matrix[i, j].OriginalI = i;
                    Matrix[i, j].OriginalJ = j;
                    //add a box collider the the raycast to work properly
                    if (Matrix[i, j].GameObject.GetComponent<BoxCollider2D>() == null)
                        Matrix[i, j].GameObject.AddComponent<BoxCollider2D>();
                }
                else
                {
                    Matrix[i, j] = null; //this will be our "empty" object
                }
            }
        }
    }
    private void Shuffle()
    {
        //shuffle
        for (int i = 0; i < CR; i++)
        {
            for (int j = 0; j < CR; j++)
            {
                if (Matrix[i, j] == null) continue;

                int random_i = Random.Range(0, CR);
                int random_j = Random.Range(0, CR);
                //swap'em
                Swap(i, j, random_i, random_j);
            }
        }
    }

    private void Swap(int i, int j, int random_i, int random_j)
    {
        //temp piece, necessary for swapping
        Piece_PG temp = Matrix[i, j];
        Matrix[i, j] = Matrix[random_i, random_j];
        Matrix[random_i, random_j] = temp;

        //set the correct positions to both objects
        if (Matrix[i, j] != null)
            Matrix[i, j].GameObject.transform.position = GetScreenCoordinatesFromVieport(i, j);
        Matrix[random_i, random_j].GameObject.transform.position = GetScreenCoordinatesFromVieport(random_i, random_j);

        //set the required properties
        if (Matrix[i, j] != null)
        { Matrix[i, j].CurrentI = i; Matrix[i, j].CurrentJ = j; }
        Matrix[random_i, random_j].CurrentI = random_i;
        Matrix[random_i, random_j].CurrentJ = random_j;
    }


    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Start:
                if (Input.GetMouseButtonUp(0))
                {
                    Shuffle();
                    gameState = GameState.Playing;
                }
                break;
            case GameState.Playing:
                timer += Time.deltaTime;
                int seconds = (int)timer % 60;
                int min = (int)timer / 60;                

                TimeText.text = "Tiempo\n" + min.ToString("00") + ":" + seconds.ToString("00");
                CheckPieceInput();
               
                break;
            case GameState.Animating:
                AnimateMovement(PieceToAnimate, Time.deltaTime);
                CheckIfAnimationEnded();
                break;
            case GameState.End:
                if (Input.GetMouseButtonUp(0))
                {   //reload
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
            default:
                break;
        }


    }

   
    /// <summary>
    /// boring UI, waiting for uGUI framework :)
    /// </summary>
    void OnGUI()
    {
        switch (gameState)
        {
            case GameState.Start:
                StartPanel.SetActive(true);
                EndPanel.SetActive(false);
                break;
            case GameState.Playing:
                StartPanel.SetActive(false);
                break;
            case GameState.End:
                int seconds = (int)timer % 60;
                int min = (int)timer / 60;
                EndText.text = min.ToString("00") + ":" + seconds.ToString("00")+"\n Haz click para empezar nuevo puzzle.";

                EndPanel.SetActive(true);
                break;
            default:
                break;
        }
    }


    void CheckPieceInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //check if a piece was hit
            if (hit.collider != null)
            {
                string name = hit.collider.gameObject.name;
                string[] parts = name.Split('-');
                int iPart = int.Parse(parts[1]);
                int jPart = int.Parse(parts[2]);

                int iFound = -1, jFound = -1;
                //find which one was hit, in our 2D array
                //there must be a better way than this one
                for (int i = 0; i < CR; i++)
                {
                    if (iFound != -1) break;
                    for (int j = 0; j < CR; j++)
                    {
                        if (iFound != -1) break;
                        if (Matrix[i, j] == null) continue;
                        if (Matrix[i, j].OriginalI == iPart
                            && Matrix[i, j].OriginalJ == jPart)
                        {
                            iFound = i; jFound = j;
                        }
                    }
                }

                Piece_PG foundPiece = Matrix[iFound, jFound];
                //check for the null piece, taking into account the game bounds
                bool pieceFound = false;
                if (iFound > 0 && Matrix[iFound - 1, jFound] == null)
                {
                    pieceFound = true;
                    toAnimateI = iFound - 1; toAnimateJ = jFound;
                }
                else if (jFound > 0 && Matrix[iFound, jFound - 1] == null)
                {
                    pieceFound = true;
                    toAnimateI = iFound; toAnimateJ = jFound - 1;
                }
                else if (iFound < CR - 1 && Matrix[iFound + 1, jFound] == null)
                {
                    pieceFound = true;
                    toAnimateI = iFound + 1; toAnimateJ = jFound;
                }
                else if (jFound < CR - 1 && Matrix[iFound, jFound + 1] == null)
                {
                    pieceFound = true;
                    toAnimateI = iFound; toAnimateJ = jFound + 1;
                }

                if(pieceFound)
                {
                    //get the coordinates of the empty object
                    screenPositionToAnimate = GetScreenCoordinatesFromVieport(toAnimateI, toAnimateJ);
                    PieceToAnimate = Matrix[iFound, jFound];
                    dragSound.Play();
                    gameState = GameState.Animating;
                }

            }

        }
    }


    private void AnimateMovement(Piece_PG toMove,  float time)
    {
        //animate it
        //Lerp could also be used, but I prefer the MoveTowards approach :)
        toMove.GameObject.transform.position = Vector2.MoveTowards(toMove.GameObject.transform.position, 
          screenPositionToAnimate , time * AnimSpeed);
    }

    /// <summary>
    /// A simple check to see if the animation has finished
    /// </summary>
    private void CheckIfAnimationEnded()
    {
        if(Vector2.Distance(PieceToAnimate.GameObject.transform.position, 
            screenPositionToAnimate) < 0.1f)
        {
            //make sure they swap, exchange positions and stuff
            Swap(PieceToAnimate.CurrentI, PieceToAnimate.CurrentJ, toAnimateI, toAnimateJ);
            gameState = GameState.Playing;
            //check if the use has won
            CheckForVictory();
        }
    }

    private void CheckForVictory()
    {
        //dual loop to check the object's properties
        
        for (int i = 0; i < CR; i++)
        {
            for (int j = 0; j < CR; j++)
            {
                if (Matrix[i, j] == null) continue;
                if (Matrix[i, j].CurrentI != Matrix[i, j].OriginalI ||
                    Matrix[i, j].CurrentJ != Matrix[i, j].OriginalJ)
                    return; //at least one wrong piece, so we haven't won (yet!)
            }
        }
        //if we did not return, then we've won!
        gameState = GameState.End;
    }

    private Vector3 GetScreenCoordinatesFromVieport(int i, int j)
    {
        //solution for screen corners found here
        //http://answers.unity3d.com/questions/486035/how-to-find-world-coordinates-of-screen-corners-wi.html
        Vector3 point = Camera.main.ViewportToWorldPoint(new Vector3(xSpace * j + 0.15f, 0.9f - ySpace * i, 0));
        point.z = 0;
        return point;
    }


}
