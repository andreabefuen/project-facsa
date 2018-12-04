using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityEnemyBehaviour : MonoBehaviour {

    public int damageValue;
    public Text scoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManagerGravity.score -= damageValue;
            scoreText.text = "SCORE: " + GameManagerGravity.score;
        }
    }
}
