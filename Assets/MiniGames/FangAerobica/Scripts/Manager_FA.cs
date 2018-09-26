using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_FA : MonoBehaviour {
    public static int Score;
    public static int Vides;
    public static int Oxigen;
    public static bool BallInGame;
    public static bool InGame;
    float InitBallSpeed;
    float InitPlayerSpeed;
    public int Nivell;
    public GameObject NewLine;
    public GameObject Instructions;
    public Text NewRecord;
    int numNewLines;
    int timeNewLine;
    Text VidesText;

    //score y oxigeno(usalo tmb o conviertelo en puntuación
    Text OxigenText;
    Text PuntuacioText;
    GameObject GameOverText;
    public GameObject[] blocks;
    private bool gameOver;
    MovingPlayer_FA scriptPlayer;
    AudioSource music;
    public AudioClip gameoversound;


    // Use this for initialization
    void Start () {
        InGame = false;
        Score = 0;
        Vides = 3;
        timeNewLine = 3000;
        numNewLines = 0;
        BallInGame = false;
        gameOver = false;
        music = gameObject.GetComponent<AudioSource>();
        VidesText = GameObject.Find("VidesText").GetComponent<Text>();
        OxigenText = GameObject.Find("OxigenText").GetComponent<Text>();
        PuntuacioText = GameObject.Find("PuntuacioText").GetComponent<Text>();
        GameOverText = GameObject.Find("GameOverText");
        GameOverText.SetActive(false);
        scriptPlayer = GameObject.Find("Player").GetComponent<MovingPlayer_FA>();
        InitBallSpeed = GameObject.Find("Ball").GetComponent<Ball_FA>().speed;
        InitPlayerSpeed = scriptPlayer.speed;

    }


    // Update is called once per frame
    void Update() {
        
        if (!gameOver) {
            VidesText.text = "Vides:\n" + Vides;
            PuntuacioText.text = "Puntuació\n" + Score;
            OxigenText.text = "Oxigen:\n" + Oxigen;
            blocks = GameObject.FindGameObjectsWithTag("Brick");
            //crea nueva fila
            if (blocks.Length < 15 || timeNewLine <= 0) {
                 Instantiate(NewLine, transform.position, transform.rotation);
                numNewLines += 1;
                timeNewLine = 3000 - (180 * numNewLines);
                if (timeNewLine < 750) timeNewLine = 750;
                scriptPlayer.speed = InitPlayerSpeed + numNewLines * 0.2f;
            }
            else if(BallInGame)
            {//si la pelota esta en juego
                timeNewLine -= 1;
            }
            GameObject.Find("Ball").GetComponent<Ball_FA>().speed = InitBallSpeed + numNewLines * 0.25f;
        }
        if (Vides < 0) {
            GameOverText.SetActive(true);
            //si no tiene vidas y es la primera vez que entra
            if (!gameOver)
            {

                //Gameover pasa el score a la otra escena
                if (ScoreManager_MM.FAScore < Score)
                {
                    ScoreManager_MM.FAScore = Score;
                    NewRecord.text = "Nuevo Record: " + Score;
                }
                music.Stop();
                music.loop = false;
                music.clip = gameoversound;
                music.Play();
            }
                foreach (GameObject block in blocks)
            {
                Destroy(block);
            }
            Destroy(GameObject.Find("Ball"));
            gameOver = true;
            VidesText.text = "Vides:\n";
        }
    }
    public void StartGame()
    {//activa el juego
        InGame = true;
        Instructions.SetActive(false);

}
}
