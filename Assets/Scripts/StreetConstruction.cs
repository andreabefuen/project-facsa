using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetConstruction : MonoBehaviour {


    BuildManager buildManager;

    public StructureBlueprint streetHorizontal;
    public StructureBlueprint streetVertical;
    public StructureBlueprint streetCross;
    public StructureBlueprint streetT;


	// Use this for initialization
	void Start () {
        buildManager = BuildManager.instance;
        streetHorizontal.isAStreet = true;
        streetVertical.isAStreet = true;
        streetCross.isAStreet = true;
        streetT.isAStreet = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //Boton construccción
    public void SelectHorizontalStreet()
    {
        Debug.Log("Horizontal Street Purchased");
        buildManager.SelectStructureToBuild(streetHorizontal);
        //buildManager.SelectStreetToBuild(streetHorizontal);
    }

    public void SelectVerticalStreet()
    {
        Debug.Log("Vertical Street Purchased");
        buildManager.SelectStructureToBuild(streetVertical);
    }

    public void SelectCrossStreet()
    {
        Debug.Log("Cross");
        buildManager.SelectStructureToBuild(streetCross);
    }

    public void SelectTStreet()
    {
        Debug.Log("T");
        buildManager.SelectStructureToBuild(streetT);
    }
}
