using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevelCanvas : MonoBehaviour {


    public void OnNextLevelButton(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
