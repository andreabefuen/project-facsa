using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiePanel : MonoBehaviour {

    public void OnRestartLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
