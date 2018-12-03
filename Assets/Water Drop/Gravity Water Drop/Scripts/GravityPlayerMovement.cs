using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlayerMovement : MonoBehaviour {

    public float maxSpeed = 10f;

    private Rigidbody2D rigid;
    private bool onGround = false;
    private bool onAir = true;
    private Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
