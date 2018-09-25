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

    //public GameObject standardEdificationPrefab;
    //public GameObject structureFacsa;

    public GraphsAlgorithms graphs;

    private StructureBlueprint structureToBuild;
   
    private Building selectedNode;

    public NodeUI nodeUI;
   




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


       //LAMAMOS AL GRAFO
       graphs = gameObject.GetComponent<GraphsAlgorithms>();
        graphs.ResetGraph();
       graphs.BusquedaEnAnchura(node.gameObject.GetComponent<Nodo>());
       
       
        

        

        Debug.Log(PlayerStats.Money);
        Debug.Log(structureToBuild.cantidadEdificios);
        node.gameObject.GetComponent<MeshRenderer>().enabled = false;


    }
    public void SelectNode (Building node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        structureToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public StructureBlueprint GetStructureToBuild()
    {
        return structureToBuild;
    }

    public void SelectStructureToBuild( StructureBlueprint structure)
    {
        structureToBuild = structure;

        DeselectNode();
       
        //Deselecionamos la zona
    }

    // Update is called once per frame
    void Update () {
        
	}
}
