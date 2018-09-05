using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    PlayerStats player;

    public StructureBlueprint edificationStructure;
    
    public StructureBlueprint standardStructure;
   

    

    // Use this for initialization
    void Start()
    {
        buildManager = BuildManager.instance;

        player = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
       
    }

    public void SelectStandardStructure()
    {
        
        
       Debug.Log("Standard Structure Purchased");
       buildManager.SelectStructureToBuild(standardStructure);
       
       

    }

    public void SelectEdification()
    {
        Debug.Log("Another structure purchased");
        buildManager.SelectStructureToBuild(edificationStructure);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
