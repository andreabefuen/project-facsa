using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    PlayerStats player;

    public StructureBlueprint structureFacsa;
    
    public StructureBlueprint standardStructure;
   

    

    // Use this for initialization
    void Start()
    {
        buildManager = BuildManager.instance;

        player = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
       
    }

    public void PurchaseStandardStructure()
    {
        if (CanBuy(structureFacsa))
        {
            Debug.Log("Standard Structure Purchased");
            buildManager.SetStructureToBuild(structureFacsa.prefab);
            player.reduceMoney(structureFacsa.cost);
            player.cantStructureFacsa++;
        }
        else
        {
            Debug.Log("You cant buy!");
            Debug.Log(player.GetMoney());
            buildManager.SetStructureToBuild(null);
        }
       

    }

    public void PurchaseAnotherStructure()
    {
        Debug.Log("Another structure purchased");
        buildManager.SetStructureToBuild(standardStructure.prefab);
    }

	
	
    public bool CanBuy(StructureBlueprint structure)
    {
        if(player.GetMoney() >= structure.cost)
        {
            return true;
        }
        return false;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
