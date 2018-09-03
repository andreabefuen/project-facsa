﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{

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
                Vector3 pos = new Vector3(-4.05f + j * 0.9f, 2.25f + i * 0.5f, 0); ;

                if (j == 0 || j == 9 ||  i == 4)
                {
                    Instantiate(bricks[0], pos, transform.rotation);

                }
                else
                {
                    Instantiate(bricks[i], pos, transform.rotation);
                }
            }
        }
        int oxy = 0;
        bricksInstantiate = GameObject.FindGameObjectsWithTag("Brick");

        while (oxy < numOxygen)
        {
            int Rdn = UnityEngine.Random.Range(0, bricksInstantiate.Length);
            BrickScript brickScriptInstant = bricksInstantiate[Rdn].GetComponent<BrickScript>();
            if (!brickScriptInstant.haveOxygen)
            {
                brickScriptInstant.haveOxygen = true;
                oxy += 1;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
