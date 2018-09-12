using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_DB : MonoBehaviour {
    public static float timer;
    public static int score;
    public AudioClip GameOverClip;
    public GameObject Instructions;
    public GameObject GameOverText;
    public GameObject TimeObject;
    public GameObject ScoreObject;
    public Text NewRecord;

    public GameObject[] Spawns;
    AudioSource music;
    bool GameOverBool;
    Text TimeText;
    Text ScoreText;
    Escenario_DB cinta1;
    Escenario_DB cinta2;
    Escenario_DB cinta3;
    SpawnScript_DB spawn1;
    SpawnScript_DB spawn2;
    SpawnScript_DB spawn3;
    float timeInGame;
    bool InGame;

    private void Start()
    {
        InGame = false;
        music = gameObject.GetComponent<AudioSource>();
        cinta1 = GameObject.Find("Cinta1").GetComponent<Escenario_DB>();
        cinta2 = GameObject.Find("Cinta2").GetComponent<Escenario_DB>();
        cinta3 = GameObject.Find("Cinta3").GetComponent<Escenario_DB>();
        

        TimeText = TimeObject.GetComponent<Text>();
        ScoreText = ScoreObject.GetComponent<Text>();
        score = 0;
        timer = 60.0f;
        GameOverBool = false;
    }


    void Update()
    {
        if (!GameOverBool && InGame)
        {
            timer -= Time.deltaTime;
            int seconds = (int)timer % 60;
            int min = (int)timer / 60;
            timeInGame += Time.deltaTime;
            cinta1.scrollSpeed = 4f + timeInGame /175;
            cinta2.scrollSpeed = 4f + timeInGame / 175;
            cinta3.scrollSpeed = 4f + timeInGame / 175;
            spawn1.speed = 2f + timeInGame / 180;
            spawn2.speed = 2f + timeInGame / 180;
            spawn3.speed = 2f + timeInGame / 180;

            TimeText.text = "Time: " + min.ToString("00") + ":" + seconds.ToString("00");
            ScoreText.text = "Score: " + score.ToString("0000");
            if (timer <= 0)
            {
                GameOverBool = true;
                TimeText.text = "Time: 00:00";
                GameOver();
            }
        }
    }
    void GameOver()
    {
        if (ScoreManager_MM.DBScore < score)
        {
            ScoreManager_MM.DBScore = score;
            NewRecord.text = "Nuevo Record: " + score;
        }
        GameOverText.SetActive(true);
        music.Stop();
        music.loop = false;
        music.volume = 1f;
        music.clip = GameOverClip;
        music.Play();
        Destroy(spawn1);
        Destroy(spawn2);
        Destroy(spawn3);
        cinta1.scrollSpeed = 0;
        cinta2.scrollSpeed = 0;
        cinta3.scrollSpeed = 0;
        GameObject[] trash;
        trash = GameObject.FindGameObjectsWithTag("Carto");
        foreach (GameObject objeto in trash)
        {
            Destroy(objeto);
        }
        trash = GameObject.FindGameObjectsWithTag("Vidre");
        foreach (GameObject objeto in trash)
        {
            Destroy(objeto);
        }
        trash = GameObject.FindGameObjectsWithTag("Organic");
        foreach (GameObject objeto in trash)
        {
            Destroy(objeto);
        }
        trash = GameObject.FindGameObjectsWithTag("Plastic");
        foreach (GameObject objeto in trash)
        {
            Destroy(objeto);
        }


    }
    public void StartGame()
    {
        Instructions.SetActive(false);
        for (int i = 0; i < Spawns.Length; i++)
        {
            Spawns[i].SetActive(true);
        }
        spawn1 = Spawns[0].GetComponent<SpawnScript_DB>();
        spawn2 = Spawns[1].GetComponent<SpawnScript_DB>();
        spawn3 = Spawns[2].GetComponent<SpawnScript_DB>();
        InGame = true;
    }

}
