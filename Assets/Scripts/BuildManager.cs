using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("More than a one BuildManager in scene!");
            return;
        }
        instance = this;

     
        
    }

    public GameObject standardEdificationPrefab;
    public GameObject structureFacsa;

    private StructureBlueprint structureToBuild;
    private Building selectedNode;

    public bool CanBuild { get {  return structureToBuild != null;  } }
    public bool HasMoney { get { return PlayerStats.Money >= structureToBuild.cost; } }

	// Use this for initialization
	/*void Start () {
        
        structureToBuild = standardEdificationPrefab;
        
    }*/

   //  public void HanPasadoDias()
   // {
   //     if(Timing.diasFicticios >= structureToBuild.tiempoEstropearseDias)
   //     {
   //         Debug.Log("Se estropea");
   //     }
   // }

    
 

    public void BuildStructureOn(Building node) //Construir en un nodo particular
    {


        if(PlayerStats.Money < structureToBuild.cost)
        {
            Debug.Log("Nos enough money");
            return;
        }

        if(structureToBuild.needWater == true && node.water == false)
        {
            Debug.Log("NO WATER CANT BUILD HERE");
            return;
        }

        PlayerStats.Money -= structureToBuild.cost;
        structureToBuild.cantidadEdificios++; // Incrementamos el número de edificaciones de ese tipo
       GameObject structure = (GameObject) Instantiate(structureToBuild.prefab, node.GetBuildPosition(), structureToBuild.prefab.transform.rotation);
       node.edification = structure;


        Debug.Log(PlayerStats.Money);
        Debug.Log(structureToBuild.cantidadEdificios);
        node.gameObject.GetComponent<MeshRenderer>().enabled = false;


    }
    public StructureBlueprint GetStructureToBuild()
    {
        return structureToBuild;
    }

    public void SelectStructureToBuild( StructureBlueprint structure)
    {
        structureToBuild = structure;
        //Deselecionamos la zona
    }


    // Update is called once per frame
    void Update () {
		
	}
}
