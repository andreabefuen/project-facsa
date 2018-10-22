using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    public string nameNextLevel;
    public float delay;



    public void PressToContinue()
    {
        StartCoroutine(NextLevel(delay));
    }

    IEnumerator NextLevel(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nameNextLevel);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
