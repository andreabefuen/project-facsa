using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript_ER : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {//si lo pasas de largo se destruye
		if(transform.position.y < -2)
        {
            Destroy(gameObject);
        }
	}
}
