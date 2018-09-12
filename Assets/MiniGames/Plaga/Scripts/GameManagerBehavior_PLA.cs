using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerBehavior_PLA : MonoBehaviour {

    public bool InGame;
    public GameObject Instructions;
    public Text goldLabel;
    public GameObject GameOverObj;
    AudioSource music;
    public AudioClip GameOverSound;
    private int gold;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "ORO: " + gold;
        }
    }
    public Text waveLabel;
    public bool gameOver = false;
    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;         
            waveLabel.text = "OLEADA: " + (wave + 1);
        }
    }
    public Text scoreLabel;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;         
            scoreLabel.text = "PUNTUACIÓN: " + score;
        }
    }
    public Text NewRecord;
    public Text healthLabel;
    public GameObject[] healthIndicator;
    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // 1
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake_PLA>().Shake();
            }
            // 2
            health = value;
            healthLabel.text = "VIDA: " + health;
            // 3
            if (health <= 0 && !gameOver)
            {
                if (ScoreManager_MM.PLAScore < Score)
                {
                    ScoreManager_MM.PLAScore = Score;
                    NewRecord.text = "Nuevo Record: " + Score;
                }
                gameOver = true;
                GameOverObj.SetActive(true);
                GameObject road = GameObject.Find("Road");
                Destroy(road);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
                music.Stop();
                music.loop = false;
                music.clip = GameOverSound;
                music.Play();

            }
            // 4 
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        Gold = 500;
        Wave = 0;
        Health = 5;
        Score = 0;
        music = GetComponent<AudioSource>();
        InGame = false;
    }
    public void StartGame()
    {
        InGame = true;
        Instructions.SetActive(false);
    }

}
