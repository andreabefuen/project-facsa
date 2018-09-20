using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{

    public GraphsAlgorithms graphsAlgorithms;

    //Colores para cada nodo del suelo, indicando si se puede construir o noç
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;


    public BuildManager build;

    private MenuConstruir menu;


    [Header("Optional")]
    public GameObject edification;

    private Renderer rend;
    private Color startColor;


    //STATS DE CADA NODO 
    [Header("STATS")]
    public bool water;
    public int totalSatisfaction;



    BuildManager buildManager;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;


        buildManager = BuildManager.instance;

        menu = GameObject.Find("Construir").GetComponent<MenuConstruir>();

        graphsAlgorithms = GameObject.Find("GameMaster").GetComponent<GraphsAlgorithms>();

    }

    public Vector3 GetBuildPosition()
    {
        return positionOffset + transform.position;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (edification != null)
        {
            Debug.Log("Can't build there!"); //Display on screen

            //Comprobamos si hemos pulsado el botón de demoler

            if (menu != null && menu.GetDemolitionActivate())
            {
                Debug.Log("DEMOLER"); //Devoler cierta cantidad de dinero
                buildManager.DestroyBuildStructure(this);
                Destroy(edification);
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                menu.SetDemolitionActivate(false);
                Debug.Log("Desactivado la demolición");
                
                return;

            }
            return;
        }
        //this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        //Mirar si es una carretera o un edificio

       
         //buildManager.BuildStreetOn(this);
        
        if(buildManager.GetStreetToBuild()!= null)
        {
            buildManager.BuildStreetOn(this);
            return;
        }
        


        buildManager.BuildStructureOn(this);

        Debug.Log("ANTES DE LA LLAMADA");

        //Llamada a la busqueda en anchura

        //graphsAlgorithms.BusquedaEnAnchura(this.gameObject.GetComponent<Nodo>());



       




    }

    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    private void OnMouseExit()
    {
        //rend.material.color = Color.blue;
        rend.material.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

