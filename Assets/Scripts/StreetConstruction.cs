using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetConstruction : MonoBehaviour {


    BuildManager buildManager;

    public StreetsBlueprint streetHorizontal;


	// Use this for initialization
	void Start () {
        buildManager = BuildManager.instance;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectHorizontalStreet()
    {
        Debug.Log("Horizontal Street Purchased");
        buildManager.SelectStreetToBuild(streetHorizontal);
    }
}
