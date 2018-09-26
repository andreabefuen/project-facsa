using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies_IO : MonoBehaviour {

    public GameObject EnemyPrefab;
    public GameObject Player;
    public int maxEnemies = 5;
    public int EnemiesInScene;
    // Use this for initialization
    void Start()
    {
        EnemiesInScene = 0;

    }

    // Update is called once per frame
    void Update()
    {//mantiene en escena tantos enemigos como maxEnemies
        if (EnemiesInScene < maxEnemies)
        {
            Spawn();
            EnemiesInScene++;
        }
    }

    void Spawn()
    {
        int rdmX = UnityEngine.Random.Range(-150, 150);
        int rdmZ = UnityEngine.Random.Range(-150, 150);
        Vector3 pos = new Vector3(rdmX, 0.01f, rdmZ);
        GameObject Enemy = Instantiate(EnemyPrefab, pos, EnemyPrefab.transform.rotation);
        Enemy.transform.SetParent(this.transform);
        
    }

}
