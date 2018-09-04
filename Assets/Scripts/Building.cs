using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour {

    public Color hoverColor;


    public BuildManager build;

    private GameObject edification;

    private Renderer rend;
    private Color startColor;


    BuildManager buildManager;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;


        buildManager = BuildManager.instance;
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
            return;
        }

        //Build an edification


        GameObject structureToBuild = BuildManager.instance.GetStructureToBuild();
        
        edification = (GameObject)Instantiate(structureToBuild, transform.position, transform.rotation);
        //edification.transform.Rotate(-90, 0, 0);

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
