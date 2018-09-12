using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class SpawnEnemy_PLA : MonoBehaviour {

    public GameObject[] Enemies;
    public GameObject[] waypoints;
    public int timeBetweenWaves = 5;

    private GameManagerBehavior_PLA gameManager;
    private float lastSpawnTime;
    public int enemiesSpawned = 0;
    private int maxEnemies = 10;
    private float spawnInterval = 4f;
    public int EnemiesKilled = 0;

    // Use this for initialization
    void Start () {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior_PLA>();

    }

    // Update is called once per frame
    void Update () {
        if (gameManager.InGame)
        {
            // 1
            int currentWave = gameManager.Wave;
            //Debug.Log(enemiesSpawned + " spawneados de " + maxEnemies);

            //Debug.Log(EnemiesKilled + " eliminados de " + maxEnemies);

            // 2
            float timeInterval = Time.time - lastSpawnTime;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval) && enemiesSpawned < maxEnemies)
            {
                newWave();
            }
            if (EnemiesKilled >= maxEnemies)
            {
                //lastSpawnTime = Time.time;
                maxEnemies = maxEnemies + 5;
                spawnInterval = spawnInterval / 1.3f;
                enemiesSpawned = 0;
                EnemiesKilled = 0;
                gameManager.Wave++;

            }
        }
      
    }
    void newWave()
    {
        int maxMonsterType = 3;
        int minMonsterType = 0;

        lastSpawnTime = Time.time;
        if(gameManager.Wave < 3)
        {
            maxMonsterType = gameManager.Wave;
        }
        else if (gameManager.Wave > 8)
        {
            minMonsterType = 1;
        }

            int Rdn = UnityEngine.Random.Range(minMonsterType, maxMonsterType);
        GameObject newEnemy = (GameObject)Instantiate(Enemies[Rdn], waypoints[0].transform.position, Enemies[Rdn].transform.rotation);
        newEnemy.GetComponent<MoveEnemy_PLA>().waypoints = waypoints;
        enemiesSpawned++;
    }
}
