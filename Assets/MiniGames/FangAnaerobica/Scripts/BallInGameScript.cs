﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInGameScript : MonoBehaviour {

    public GameObject Tap;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ManagerScript.BallInGame = true;
            Tap.SetActive(true);
        }
    }

}
