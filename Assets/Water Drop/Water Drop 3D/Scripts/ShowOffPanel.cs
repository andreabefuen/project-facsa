using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOffPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DesactivePanel", 3f); 

    }
	

    void DesactivePanel()
    {
        this.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
