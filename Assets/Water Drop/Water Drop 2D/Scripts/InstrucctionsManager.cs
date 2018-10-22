using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrucctionsManager : MonoBehaviour {

    public GameObject info;

	// Use this for initialization
	void Start () {
        

        StartCoroutine(PauseTime(0.5f));

		
	}

    IEnumerator PauseTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
    }
	
    public void PressToStart()
    {
        
        Time.timeScale = 1;

        DisableInfo();
        
    }

    private void DisableInfo()
    {
        info.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
