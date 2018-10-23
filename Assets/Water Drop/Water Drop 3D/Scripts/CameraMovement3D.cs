using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement3D : MonoBehaviour {

    public float velocityX;

	// Use this for initialization
	void Start () {

        velocityX *= -1;

        GetComponent<Rigidbody>().velocity = new Vector3(velocityX, 0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
