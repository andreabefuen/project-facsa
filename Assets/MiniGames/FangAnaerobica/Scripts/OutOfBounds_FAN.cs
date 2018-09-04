using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds_FAN : MonoBehaviour {

    public Transform ball;
    public GameObject tap;
    Vector3 startingPos;


	// Use this for initialization
	void Start () {
        startingPos = ball.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.rigidbody.velocity = Vector3.zero;
            collision.transform.position = startingPos;
            tap.SetActive(false);
            ManagerScript_FAN.Life -= 1;
        }
    }
}
