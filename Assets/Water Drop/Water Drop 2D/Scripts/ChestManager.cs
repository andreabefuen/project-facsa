﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour {

    public Animator anim;
   

	// Use this for initialization
	void Start () {
        anim.GetComponent<Animator>();

        //animation.GetComponent<Animation>();

        //animation.Stop();

        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.enabled = true;
        }
    }
}
