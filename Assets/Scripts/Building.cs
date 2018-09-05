using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour {

    public Color hoverColor;


    public BuildManager build;

    private MenuConstruir menu;

    private GameObject edification;

    private Renderer rend;
    private Color startColor;


    PlayerStats player;
   


    BuildManager buildManager;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;


        buildManager = BuildManager.instance;

        menu = GameObject.Find("Construir").GetComponent<MenuConstruir>();

        player = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (buildManager.GetStructureToBuild() == null)
        {
            return;
        }

        if(edification != null)
        {
            Debug.Log("Can't build there!"); //Display on screen

            //Comprobamos si hemos pulsado el botón de demoler

            if (menu!=null &&   menu.GetDemolitionActivate())
            {
                Debug.Log("DEMOLER"); //Devoler cierta cantidad de dinero
                Destroy(edification);
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                menu.SetDemolitionActivate(false);
                Debug.Log("Desactivado la demolición");
                return;
                
            }
            return;
        }

        //Build an edification

        if(player.cantStructureFacsa > 0)
        {
            GameObject structureToBuild = BuildManager.instance.GetStructureToBuild();

            //edification = (GameObject)Instantiate(structureToBuild, transform.position, transform.rotation);

            edification = (GameObject)Instantiate(structureToBuild, transform.position, structureToBuild.transform.rotation);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //edification.transform.Rotate(-90, 0, 0);
            player.cantStructureFacsa--;

        }

        else
        {
            Debug.Log("Compra edificios");
            
        }




    }

    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetStructureToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        //rend.material.color = Color.blue;
        rend.material.color = startColor;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
