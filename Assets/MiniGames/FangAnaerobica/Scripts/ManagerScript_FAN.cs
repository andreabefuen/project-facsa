using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript_FAN : MonoBehaviour {

    public static int Score;
    public static int Life;
    public static int NumBacteries;
    public static bool BallInGame;
    public GameObject GoodBactery;
    public GameObject BadBactery;
    public GameObject GameOverObject;
    public GameObject Instructions;
    public AudioSource GameOverSound;
    public static bool InGame;
    public Text NewRecord;
    int TimeToRespawn;
    Text ScoreText;
    Text LifeText;
    GameObject[] Spawners;
    bool finish;


    // Use this for initialization
    void Start () {
        InGame = false;
        Physics.gravity = new Vector3(0, -4.4F, -11);
        GameOverObject.SetActive(false);
        TimeToRespawn = 0;
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        LifeText = GameObject.Find("LifeText").GetComponent<Text>();
        Spawners = GameObject.FindGameObjectsWithTag("Spawner");
        Score = 0;
        Life = 2;
        TimeToRespawn = 300;
        BallInGame = false;
        ScoreText.text = "Puntuació\n" + Score.ToString("00000");
        LifeText.text = "Boles\n " + Life;
        finish = false;
        NumBacteries = 0;
        while (NumBacteries < 3)
        {
            CreateBactery();
        }
    }

    // Update is called once per frame
    void Update () {
        if (BallInGame && InGame)
        {
            ScoreText.text = "Puntuación\n" + Score.ToString("00000");
            LifeText.text = "Pelota\n " + Life;
            if (TimeToRespawn <= 0 || NumBacteries <3)
            {
                CreateBactery();
                TimeToRespawn = 300;
            }
            else
            {
                TimeToRespawn -= 1;
            }
        }
        if(Life < 0)
        {
            GameOver();
        }
    }
    public void StartGame()
    {
        InGame = true;
        Instructions.SetActive(false);
    }
    void GameOver()
    {
        if (ScoreManager_MM.FANScore < Score)
        {
            ScoreManager_MM.FANScore = Score;
            NewRecord.text = "Nuevo Record: " + Score;
        }
        Physics.gravity = new Vector3(0, -9.81f, 0);

        ScoreText.text = "Puntuació\n" + Score.ToString("00000");
        LifeText.text = "Boles\n 0";
        BallInGame = false;
        GameOverObject.SetActive(true);
        if (!finish)
        {
            GameOverSound.Play();
            finish = true;
        }
        Destroy(GameObject.Find("Ball"));
        GameObject[] Bacteries = GameObject.FindGameObjectsWithTag("Bactery");
        foreach (GameObject bactery in Bacteries)
        {
            Destroy(bactery);
        }
        GameObject[] Spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawn in Spawners)
        {
            Destroy(spawn);
        }

    }
    void CreateBactery()
    {
        int rdm = UnityEngine.Random.Range(0, Spawners.Length);
        if (Spawners[rdm].transform.childCount <= 0)
        {
            int rdm2 = UnityEngine.Random.Range(0, 2);
            if (rdm2 == 0)
            {
                GameObject Bactery = Instantiate(GoodBactery, Spawners[rdm].transform.position, Quaternion.identity);
                Bactery.transform.parent = Spawners[rdm].transform;
            }
            else
            {
                GameObject Bactery = Instantiate(BadBactery, Spawners[rdm].transform.position, Quaternion.identity);
                Bactery.transform.parent = Spawners[rdm].transform;
            }
            NumBacteries += 1;
        }
    }
}
