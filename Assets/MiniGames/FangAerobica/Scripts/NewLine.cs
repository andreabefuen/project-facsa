using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLine : MonoBehaviour
{

    public GameObject[] bricks;
    public int numOxygen = 3;
    GameObject[] bricksInstantiate = new GameObject[10];
    GameObject[] bricksInScene;

    // Use this for initialization
    void Start()
    {
        int Rdn = UnityEngine.Random.Range(0, bricks.Length - 1);
        bricksInScene = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject block in bricksInScene)
        {
            block.transform.position = transform.position = new Vector3(block.transform.position.x, block.transform.position.y - 0.5f, 0.0f);
        }
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(-4.05f + i * 0.9f, 4.75f, 0); ;
            bricksInstantiate[i] = Instantiate(bricks[Rdn], pos, transform.rotation);
        }
        
        int oxy = 0;
        
        while (oxy < numOxygen)
        {
            Rdn = UnityEngine.Random.Range(0, bricksInstantiate.Length);
            BrickScript brickScriptInstant = bricksInstantiate[Rdn].GetComponent<BrickScript>();
            if (!brickScriptInstant.haveOxygen)
            {
                brickScriptInstant.haveOxygen = true;
                oxy += 1;
            }
        }
        Destroy(gameObject);
    }

}