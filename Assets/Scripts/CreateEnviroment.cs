using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnviroment : MonoBehaviour {

    public int filas;
    public int columnas;

    public GameObject node;

    private float heightNode, widthNode;

    private Vector3 offset = new Vector3 (2,2,2);

    private GameObject[,] matrix;
    Vector3 position = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {

        heightNode = 5f;
        widthNode = 5f;

        matrix = new GameObject[filas, columnas];

        for(int f = 0; f < filas; f++)
        {

            for (int c = 0; c < columnas; c++)
            {
                transform.position = position;
                matrix[f, c] = Instantiate(node);
                position += offset;

            }

           // position = (widthNode, 0, 0);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
