﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript_IO : MonoBehaviour {
    public Text ScoreText;
    public Text NewRecord;
    public GameObject Player;
    public GameObject EnemySpawn;
    public GameObject Instructions;
    public GameObject FoodSpawn;
    public GameObject GameOverPanel;
    public AudioClip GameOverSound;
    public AudioSource Music;

    // Use this for initialization
    public void StartGame () {
        if (FoodSpawn.GetComponent<FoodSpawner_IO>().FoodInScene > 200)
        {
            Player.GetComponent<MovingPlayer_IO>().StartGame = true;
            Instructions.SetActive(false);
            EnemySpawn.SetActive(true);
        }
	}
    public void GameOver()
    {
        if (ScoreManager_MM.IOScore < Player.GetComponent<MovingPlayer_IO>().Points)
        {
            ScoreManager_MM.IOScore = Player.GetComponent<MovingPlayer_IO>().Points;
            NewRecord.text = "Nuevo Record: " + Player.GetComponent<MovingPlayer_IO>().Points;
        }
        Music.Stop();
        Music.loop = false;
        Music.clip = GameOverSound;
        Music.Play();
        GameOverPanel.SetActive(true);
        Destroy(Player.GetComponent<MovingPlayer_IO>());
        Destroy(FoodSpawn);
        Destroy(EnemySpawn);
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
        foreach(GameObject Enemy in Enemies)
        {
            Destroy(Enemy);
        }

    }
    // Update is called once per frame
    void Update () {
        ScoreText.text = "Score: " + Player.GetComponent<MovingPlayer_IO>().Points;
        if(Player.GetComponent<MovingPlayer_IO>().Points > (EnemySpawn.GetComponent<SpawnerEnemies_IO>().maxEnemies - 4) * 100)
        {
            EnemySpawn.GetComponent<SpawnerEnemies_IO>().maxEnemies++;
        }
	}
}