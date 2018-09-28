using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnvironment : MonoBehaviour {

    public GameObject water;
    public int cantidadWater;
    public GameObject background;
    public int cantidadBackground;

    private float width, widthBackground;
    private Vector3 newPosition,newPositionBackground;


	// Use this for initialization
	void Start () {
        width = water.GetComponent<BoxCollider2D>().size.x;
        newPosition = new Vector3(-10 + width, -6.5f, 0.1f);

        CreateWater();

        widthBackground = background.transform.GetComponent<Renderer>().bounds.size.x;
        newPositionBackground = new Vector3(-15.55f, 0, 0);

        CreateBackground();


        //finalPlace.position = newPosition;
    }

    void CreateBackground()
    {
        for(int i = 0; i<cantidadBackground; i++)
        {
            newPositionBackground.x += widthBackground;
            Instantiate(background, newPositionBackground, Quaternion.identity);
        }


    }


    void CreateWater()
    {
        for (int i = 0; i < cantidadWater; i++)
        {
            newPosition.x += width;
            Instantiate(water, newPosition, Quaternion.identity);

        }
    }
	
	// Update is called once per frame
	void Update () {

       
		
	}
}
