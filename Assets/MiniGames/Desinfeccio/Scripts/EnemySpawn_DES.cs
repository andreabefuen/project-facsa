using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_DES : MonoBehaviour
{
    public GameObject enemy;


    // Use this for initialization
    void Start()
    {
        Manager_DES.EnemiesInScene += 27;
         for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Vector3 pos = new Vector3(-3.25f + j * 0.9f, 2.25f + i * 1f, 0); ;
                Instantiate(enemy, pos, transform.rotation);
            }
        }
        Destroy(gameObject);
    }

}
