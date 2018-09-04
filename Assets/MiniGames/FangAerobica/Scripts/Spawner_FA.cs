using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_FA : MonoBehaviour {

    public GameObject[] bricks;
    public int numOxygen = 13;
    public GameObject[] bricksInstantiate;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 pos = new Vector3(-4.05f + j * 0.9f, 2.75f + i * 0.5f, 0); ;
                Instantiate(bricks[i], pos, transform.rotation);

            }
        }
        int oxy = 0;
        bricksInstantiate = GameObject.FindGameObjectsWithTag("Brick");
      
        while (oxy < numOxygen) {
            int Rdn = UnityEngine.Random.Range(0, bricksInstantiate.Length);
            BrickScript_FA brickScriptInstant = bricksInstantiate[Rdn].GetComponent<BrickScript_FA>();
            if (!brickScriptInstant.haveOxygen) {
                brickScriptInstant.haveOxygen = true;
                oxy += 1;
            }
        }
        Destroy(gameObject);
    }

}
