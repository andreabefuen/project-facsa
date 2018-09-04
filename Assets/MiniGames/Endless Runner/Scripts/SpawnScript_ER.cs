using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript_ER : MonoBehaviour {

    public GameObject Obstacle;
    public GameObject Player;
    public GameObject Capsule;

    public int TimeToSpawn;
    int TimeLastSpawn;
    int TimeLastCapsule;
    float TimeCapsule;
    // Use this for initialization
    void Start () {
        TimeToSpawn = 250;
        TimeLastSpawn = 0;
        TimeLastCapsule = 0;
    }

    // Update is called once per frame
    void Update () {
        TimeCapsule = TimeToSpawn * 1.4f;
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z + 50);
        if (TimeLastSpawn >= TimeToSpawn)
        {
            SpawnObstacle();
            TimeLastSpawn = 0;
        }
        else
        {
            TimeLastSpawn++;
        }
        if (TimeLastCapsule >= TimeCapsule)
        {
            SpawnCapsule();
            TimeLastCapsule = 0;
        }
        else
        {
            TimeLastCapsule++;
        }
    }

    public void SpawnObstacle()
    {
        int rdm2 = UnityEngine.Random.Range(0, 3);
        Instantiate(Obstacle, new Vector3(transform.position.x + (-1 + rdm2), transform.position.y, transform.position.z), Obstacle.transform.rotation);

    }
    public void SpawnCapsule()
    {
        int rdm2 = UnityEngine.Random.Range(0, 3);
        Instantiate(Capsule, new Vector3(transform.position.x + (-1 + rdm2), transform.position.y, transform.position.z), Capsule.transform.rotation);
    }

}
