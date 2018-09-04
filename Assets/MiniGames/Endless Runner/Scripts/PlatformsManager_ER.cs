using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager_ER : MonoBehaviour {

    public GameObject Spawner;
    public GameObject[] Platforms;
    int numPlatforms = 6;
    public List<GameObject> PlatformsList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        PlatformsList.Add(Instantiate(Platforms[0], new Vector3(Platforms[0].transform.position.x, Platforms[0].transform.position.y, Platforms[0].transform.position.z), Platforms[0].transform.rotation));

        for (int i = 0; i < 5; i++)
        {
            int rdm = UnityEngine.Random.Range(0, Platforms.Length);
            PlatformsList.Add(Instantiate(Platforms[rdm], new Vector3(Platforms[rdm].transform.position.x, Platforms[rdm].transform.position.y, Platforms[rdm].transform.position.z + (i * 18) + 18), Platforms[rdm].transform.rotation));
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.position.z > PlatformsList[1].transform.position.z)
        {
            if((numPlatforms+1) % 6 == 0)
            {
                GetComponent<PlayerMove_ER>().speed += 0.25f;
                Spawner.GetComponent<SpawnScript_ER>().TimeToSpawn -= 10;
            }
            int rdm = UnityEngine.Random.Range(1, Platforms.Length);
            PlatformsList.Add(Instantiate(Platforms[rdm], new Vector3(Platforms[rdm].transform.position.x, Platforms[rdm].transform.position.y, Platforms[rdm].transform.position.z + numPlatforms *18), Platforms[rdm].transform.rotation));
            numPlatforms++;
            Destroy(PlatformsList[0]);
            PlatformsList.RemoveAt(0);
        }
    }
}
