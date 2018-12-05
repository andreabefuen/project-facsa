using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour {

    public Text scoreText;

    public void OnPressStartButton()
    {
        Time.timeScale = 1;
        scoreText.text = "SCORE: " + GameManagerGravity.score;
        this.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
