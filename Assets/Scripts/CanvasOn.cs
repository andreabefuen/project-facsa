using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOn : MonoBehaviour {

    public Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas.gameObject.SetActive(false);
		
	}


    public void canvasActivate()
    {
        canvas.gameObject.SetActive(true);
        Debug.Log("Se ha estropeado el edificio ");
    }
    

	
	// Update is called once per frame
	void Update () {
		
	}
}
