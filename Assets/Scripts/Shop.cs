using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    // Use this for initialization
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardStructure()
    {
        Debug.Log("Standard Structure Purchased");
        buildManager.SetStructureToBuild(buildManager.standardEdificationPrefab);

    }

    public void PurchaseAnotherStructure()
    {
        Debug.Log("Another structure purchased");
        buildManager.SetStructureToBuild(buildManager.structureFacsa);
    }

	
	
	// Update is called once per frame
	void Update () {
		
	}
}
