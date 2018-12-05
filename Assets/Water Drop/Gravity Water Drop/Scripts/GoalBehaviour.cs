using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalBehaviour : MonoBehaviour {

    public GameObject PassLevelPanel;
    public Text finalScore;

	// Use this for initialization
	void Start () {
        PassLevelPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PassLevelPanel.SetActive(true);
            finalScore.text = "SCORE: " + GameManagerGravity.score;
            Time.timeScale = 0;
        }
    }
}
