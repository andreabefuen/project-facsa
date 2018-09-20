﻿using System.Collections;
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

    //public GameObject standardEdificationPrefab;
    //public GameObject structureFacsa;

    public GraphsAlgorithms graphs;

    private StructureBlueprint structureToBuild;
    private StreetsBlueprint streetToBuild;
    private Building selectedNode;

   




    public bool CanBuild { get {  return structureToBuild != null;  } }
    public bool HasMoney { get { return PlayerStats.Money >= structureToBuild.cost; } }

    public void BrokenStructure()
    {
        if(Timing.diasFicticios > structureToBuild.tiempoEstropearseDias)
        {
            Debug.Log("Se ha estropeado");
            //structureToBuild.prefab.gameObject.GetComponent<Renderer>().material.color = Color.red;



        }
    }

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
   public void DestroyBuildStructure(Building node)
    {
        PlayerStats.Money += structureToBuild.moneyOfDemolition;
        structureToBuild.cantidadEdificios--;
        EdificationUpdate.listOfStructures.Remove(structureToBuild);

        Debug.Log(structureToBuild.cantidadEdificios);
    }
    
    public void BuildStreetOn(Building node)
    {
        if(PlayerStats.Money < streetToBuild.cost)
        {
            Debug.Log("Not enough money to build the street");
            return;
        }

        PlayerStats.Money -= streetToBuild.cost;
        streetToBuild.streetCount++;
        GameObject street = (GameObject)Instantiate(streetToBuild.prefab, node.GetBuildPosition(), streetToBuild.prefab.transform.rotation);
        node.edification = street;
        streetToBuild.nodeAsociate = node;

        node.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
 

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
        structureToBuild.nodeAsociate = node;

        EdificationUpdate.listOfStructures.Add(structureToBuild);

        //Debug.Log("Antes de la llamada");
        //GraphsAlgorithms graphsAlgorithms = gameObject.GetComponent<GraphsAlgorithms>();
        //
        //
        ////Afecta a todos los nodos cercanos (un rango de 3)
        //
        // Debug.Log("Antes de la llamada");
        // graphs.BusquedaEnAnchura(node.gameObject.GetComponent<Nodo>());
        //graphsAlgorithms.BusquedaEnAnchura(node.gameObject.GetComponent<Nodo>());


        //LLAMAMOS AL GRAFO
       //graphs = gameObject.GetComponent<GraphsAlgorithms>();
       //graphs.BusquedaEnAnchura(node.gameObject.GetComponent<Nodo>());
       //
       
        

        

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
        streetToBuild = null;
        //Deselecionamos la zona
    }

    public void SelectStreetToBuild (StreetsBlueprint street)
    {
        streetToBuild = street;
        structureToBuild = null;
    }

    public StreetsBlueprint GetStreetToBuild()
    {
        return streetToBuild;
    }

    // Update is called once per frame
    void Update () {
        
	}
}
