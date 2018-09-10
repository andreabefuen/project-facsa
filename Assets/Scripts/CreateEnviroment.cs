using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnviroment : MonoBehaviour {

    public int filas;
    public int columnas;

    public GameObject node;

    //private float heightNode, widthNode;

    private Vector3 aux = new Vector3 (1.5f,0,0);

    private float offset = 1.5f;

    private GameObject[,] matrix;
    Vector3 position = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {

        //heightNode = 5f;
       // widthNode = 5f;

        matrix = new GameObject[filas, columnas];

        for(int f = 0; f < filas; f++)
        {

            for (int c = 0; c < columnas; c++)
            {
                node.transform.position = position;
                
                matrix[f, c] = Instantiate(node);
                position += aux;

            }
            position = new Vector3(0, 0, position.z + offset);

            //offset = new Vector3(0, 0, 1.5f);

           // position = (widthNode, 0, 0);
        }


        CreateGrafo();

    }

    public void CreateGrafo()
    {


        for (int f = 0; f < filas; f++)
        {

            for (int c = 0; c < columnas; c++)
            {
                matrix[f, c].GetComponent<Nodo>().positionText.text = "(" + f + "," + c + ")";

                //ESQUINAS
                if(f == 0 && c == 0)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, 0].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f , c+1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, c+1].GetComponent<Nodo>());

                }
                else if( f == filas-1 && c == columnas-1)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f, c - 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c - 1].GetComponent<Nodo>());
                }

                else if(f == filas -1 && c == 0)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f , c+1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f-1, c+1 ].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c ].GetComponent<Nodo>());
                }

                else if(f == 0 && c == columnas - 1)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[0 , c-1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[1, c -1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[1, c ].GetComponent<Nodo>());
                }
                //BORDES
                else if( f == 0)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f, c - 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f, c + 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f+1, c-1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f+1, c].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f+1, c+1].GetComponent<Nodo>());
                }

                else if( c == 0)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f+1, c ].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f-1, c].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, c + 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, c].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c +1].GetComponent<Nodo>());
                }

                else if( f == filas -1)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f, c - 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f, c + 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c - 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c + 1].GetComponent<Nodo>());

                }
                else if (c == columnas - 1)
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f+1 , c ].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f -1 , c].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, c-1 ].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f , c-1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c - 1].GetComponent<Nodo>());

                }
                //EN MEDIO
                else
                {
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, c-1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f , c-1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c - 1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, c].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f - 1, c ].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f + 1, c+1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f , c+1].GetComponent<Nodo>());
                    matrix[f, c].GetComponent<Nodo>().adyacentes.Add(matrix[f -1 , c + 1].GetComponent<Nodo>());
                }

            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
