using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    PlayerStats player;

    public GameObject streetMenu;

    public StructureBlueprint edificationStructure;
    
    public StructureBlueprint standardStructure;

    public StructureBlueprint factoryStructure;


    private bool streetMenuActivate = false;

    private List<StructureBlueprint> lista = new List<StructureBlueprint>();

    // Use this for initialization
    void Start()
    {
        buildManager = BuildManager.instance;

        player = GameObject.Find("GameMaster").GetComponent<PlayerStats>();


        //AÑADIR CADA TIPO DE EDIFICIO A LA LISTA
        lista.Add(edificationStructure);
        lista.Add(standardStructure);
        lista.Add(factoryStructure);
        //Debug.Log(lista.Count);
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

    public void SelectFactory()
    {
        Debug.Log("Factory structure purchased");
        buildManager.SelectStructureToBuild(factoryStructure);
    }

    //Lista que guarda todo los tipos de estructuras que hay
    public List<StructureBlueprint> TypesStructure()
    {
        
        return lista;
    }

    public void SelectStreetMenu()
    {
        this.gameObject.SetActive(false);
        streetMenu.SetActive(!streetMenuActivate);
        streetMenuActivate = !streetMenuActivate;

    
    }

	// Update is called once per frame
	void Update () {
		
	}
}
