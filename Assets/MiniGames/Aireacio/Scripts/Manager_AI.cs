using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_AI : MonoBehaviour {
    public static float timer;
    public static int score;
    public static int velocity;
    public int numTurbin;
    public AudioSource music;
    public AudioSource newLevel;
    public AudioClip GameOverMusic;
    bool GameOverBool;
    GameObject Turbina;
    Slider VelSlider;
    Slider TimeSlider;
    Text ScoreText;
    GameObject GameOverText;
    public GameObject Instructions;
    public GameObject Board;
    bool InGame;
    float timeInGame;

    private void Start()
    {
        InGame = false;
        Physics2D.queriesStartInColliders = false;
        GameOverText = GameObject.Find("GameOverText");
        GameOverText.SetActive(false);
        VelSlider = GameObject.Find("VelSlider").GetComponent<Slider>();
        TimeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        Turbina = GameObject.Find("Turbina");
        timer = 100;
        score = 0;
        numTurbin = 1;
        GameOverBool = false;
    }


    void Update()
    {
        if (!GameOverBool && InGame)
        {
            timer -= Time.deltaTime * (float)(numTurbin*0.75);
            if (timer > 100) timer = 100;
            TimeSlider.value = timer;
            VelSlider.value = velocity;
            if (VelSlider.value >= 100) {
                newLevel.Play();
                numTurbin += 1;
                velocity = 0;
                if (numTurbin == 3) BoardManager_AI.ElementsEliminate -= 1;
                else if (numTurbin == 7) BoardManager_AI.ElementsEliminate -= 1;
            }
           // TimeText.text = "Time: " + min.ToString("00") + ":" + seconds.ToString("00");
            ScoreText.text = "Score\n" + score.ToString("0000") + "\nNum.Turbinas\n" + numTurbin;
            Turbina.transform.Rotate(0, 0, Time.deltaTime*(velocity*2));
            if (timer <= 0)
            {
                GameOverBool = true;
                GameOver();

            }
        }
    }
    public void StartGame()
    {
        Instructions.SetActive(false);
        Board.SetActive(true);
        InGame = true;
    }
    void GameOver()
    {
        Physics2D.queriesStartInColliders = true;
        GameOverText.SetActive(true);
        music.Stop();
        music.loop = false;
        music.clip = GameOverMusic;
        music.Play();
        GameObject[] tiles;
        tiles = GameObject.FindGameObjectsWithTag("Tiles");
        foreach (GameObject objeto in tiles)
        {
            Destroy(objeto);
        }

    }

}
