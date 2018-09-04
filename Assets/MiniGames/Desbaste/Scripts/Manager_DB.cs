using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_DB : MonoBehaviour {
    public static float timer;
    public static int score;
    public AudioClip GameOverClip;
    AudioSource music;
    bool GameOverBool;
    Text TimeText;
    Text ScoreText;
    GameObject GameOverText;
    Escenario_DB cinta1;
    Escenario_DB cinta2;
    Escenario_DB cinta3;
    SpawnScript_DB spawn1;
    SpawnScript_DB spawn2;
    SpawnScript_DB spawn3;
    float timeInGame;

    private void Start()
    {
        music = gameObject.GetComponent<AudioSource>();
        cinta1 = GameObject.Find("Cinta1").GetComponent<Escenario_DB>();
        cinta2 = GameObject.Find("Cinta2").GetComponent<Escenario_DB>();
        cinta3 = GameObject.Find("Cinta3").GetComponent<Escenario_DB>();
        spawn1 = GameObject.Find("Spawn1").GetComponent<SpawnScript_DB>();
        spawn2 = GameObject.Find("Spawn2").GetComponent<SpawnScript_DB>();
        spawn3 = GameObject.Find("Spawn3").GetComponent<SpawnScript_DB>();

        GameOverText = GameObject.Find("GameOverText");
        GameOverText.SetActive(false);
        TimeText = GameObject.Find("TimeText").GetComponent<Text>();
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score = 0;
        timer = 60.0f;
        GameOverBool = false;
    }


    void Update()
    {
        if (!GameOverBool)
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

}
