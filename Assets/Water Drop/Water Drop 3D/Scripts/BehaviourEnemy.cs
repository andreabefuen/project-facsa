using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Colision");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
