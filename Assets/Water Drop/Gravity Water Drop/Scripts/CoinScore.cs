using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour {

    public Text scoreText;
    public int coinValue;

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManagerGravity.score += coinValue;
            scoreText.text = "SCORE: " + GameManagerGravity.score;
            audio.Play();
            Destroy(this.gameObject, 0.25f);
        }
    }
}
