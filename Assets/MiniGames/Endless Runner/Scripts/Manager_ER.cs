using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_ER : MonoBehaviour {
    public GameObject instructions;
    public static bool InGame;
	// Use this for initialization
	void Start () {
        InGame = false;
	}
	
	// Update is called once per frame
	public void StartGame () {//se encarga de iniciar cuando le da al start
        InGame = true;
        instructions.SetActive(false);	
	}
}
