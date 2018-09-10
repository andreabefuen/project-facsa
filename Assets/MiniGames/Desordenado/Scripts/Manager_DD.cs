using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_DD : MonoBehaviour {
    public static bool InGame;
    public GameObject Instructions;
	// Use this for initialization
	void Start () {
        InGame = false;
	}
	public void StartGame()
    {
        Instructions.SetActive(false);
        InGame = true;
    }
	// Update is called once per frame

}
