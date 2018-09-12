using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_DES : MonoBehaviour
{
    public static int Score;
    public static int Vides;
    public static int Contaminacio;
    public static int EnemyBullets;
    public static int MaxBullets;
    public static int BossLive;
    public static int Fase;
    public Text NewRecord;
    public GameObject Instructions;
    private bool ChangeFase;
    public static int EnemiesInScene;
    public GameObject Boss;
    public GameObject Spawner1;
    public GameObject Spawner2;
    bool GameOverBool;
    bool InGame;
    AudioSource Music;
    public AudioClip GameOverMusic;

    Text VidesText;
    Text PuntuacioText;
    Slider ContaminacioSlider;
    Slider BossLifeSlider2;
    GameObject BossLifeText;
    GameObject BossLifeSlider;
    GameObject GameOverText;
    private GameObject[] enemies;
    private GameObject[] Shoots;

    // Use this for initialization
    void Start()
    {
        InGame = false;
        GameOverBool = false;
        Score = 0;
        Vides = 5;
        Contaminacio = 100;
        VidesText = GameObject.Find("VidesText").GetComponent<Text>();
        PuntuacioText = GameObject.Find("PuntuacioText").GetComponent<Text>();
        ContaminacioSlider = GameObject.Find("ContaminacioSlider").GetComponent<Slider>();
        BossLifeSlider = GameObject.Find("BossSlider");
        BossLifeSlider2 = GameObject.Find("BossSlider").GetComponent<Slider>();
        BossLifeText = GameObject.Find("BossText");
        GameOverText = GameObject.Find("GameOverText");
        Music = gameObject.GetComponent<AudioSource>();
        GameOverText.SetActive(false);
        BossLifeSlider.SetActive(false);
        BossLifeText.SetActive(false);
        MaxBullets = 4;
        Fase = 1;
        ChangeFase = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOverBool && InGame)
        {
            VidesText.text = "Vidas:\n" + Vides;
            PuntuacioText.text = "Puntuación\n" + Score;
            if (Contaminacio > 100)
                Contaminacio = 100;
            ContaminacioSlider.value = Contaminacio;
            BossLifeSlider2.value = BossLive;
            if (Vides < 0 && !GameOverBool || Contaminacio <= 0 && !GameOverBool)
            {
                GameOver();
            }
            FaseManager();
            StartCoroutine(FaseState());
            EnemiesInScene = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Boss").Length;
        }
    }

    //distintas fases
    public void StartGame()
    {
        Instructions.SetActive(false);
        InGame = true;
    } 
    void GameOver()
    {
        if (ScoreManager_MM.DESScore < Score)
        {
            ScoreManager_MM.DESScore = Score;
            NewRecord.text = "Nuevo Record: " + Score;
        }
        GameOverBool = true;
        VidesText.text = "Vides:\n";
        Music.Stop();
        Music.loop = false;
        Music.clip = GameOverMusic;
        Music.Play();
        GameOverText.SetActive(true);
        enemies = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy2");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        Shoots = GameObject.FindGameObjectsWithTag("Shoot");
        foreach (GameObject shoot in Shoots)
        {
            Destroy(shoot);
        }
    }
    void FaseManager()
    {
        if (Fase == 1 && ChangeFase)
        {
            BossLifeSlider.SetActive(false);
            BossLifeText.SetActive(false);
            Destroy(GameObject.Find("Enemy2Spawn"));
            enemies = GameObject.FindGameObjectsWithTag("Enemy2");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            Shoots = GameObject.FindGameObjectsWithTag("Shoot");
            foreach (GameObject shoot in Shoots)
            {
                Destroy(shoot);
            }
            EnemyBullets = 0;
            Destroy(GameObject.FindGameObjectWithTag("Spawner"));
            Instantiate(Spawner1, transform.position, transform.rotation);
            ChangeFase = false;
        }
        else if (Fase == 2 && ChangeFase)
        {
            Shoots = GameObject.FindGameObjectsWithTag("Shoot");
            foreach (GameObject shoot in Shoots)
            {
                Destroy(shoot);
            }
            EnemyBullets = 0;
            Vector3 pos = new Vector3(-4f, 7f, 0); ;

            Instantiate(Spawner1, transform.position, transform.rotation);
            Instantiate(Spawner2, pos, transform.rotation);
            ChangeFase = false;

        }
        else if (Fase == 3 && ChangeFase)
        {
            Destroy(GameObject.Find("Enemy2Spawn"));
            enemies = GameObject.FindGameObjectsWithTag("Enemy2");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            Shoots = GameObject.FindGameObjectsWithTag("Shoot");
            foreach (GameObject shoot in Shoots)
            {
                Destroy(shoot);
            }
            EnemyBullets = 0;
            Destroy(GameObject.FindGameObjectWithTag("Spawner"));
            Vector3 pos = new Vector3(0, 4f, 0); ;
            Instantiate(Boss, pos, transform.rotation);
            BossLifeSlider.SetActive(true);
            BossLifeText.SetActive(true);
            ChangeFase = false;
        }

    }

    IEnumerator FaseState()
    {
        yield return new WaitForSeconds(5);
        if (!GameOverBool)
        {
            if (Fase == 1 && !ChangeFase)
            {
                if (EnemiesInScene <= 0)
                {

                    Fase = 2;
                    ChangeFase = true;
                }
            }
            else if (Fase == 2 && !ChangeFase)
            {
                if (EnemiesInScene <= 0)
                {
                    Fase = 3;
                    ChangeFase = true;
                }

            }
            else if (Fase == 3 && !ChangeFase)
            {
                if (EnemiesInScene <= 0)
                {
                    Fase = 1;
                    ChangeFase = true;
                    MaxBullets += 4;
                }
            }
        }
    }

}
