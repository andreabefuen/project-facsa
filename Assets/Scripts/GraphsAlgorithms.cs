using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphsAlgorithms : MonoBehaviour {

    CreateEnviroment createEnviroment;
    GameObject[,] matrix;

    public int maxDistancia = 10;

    Queue<Nodo> cola = new Queue<Nodo>();
    // Nodo w = new Nodo();
    Nodo v;
    List<Nodo> vecinos = new List<Nodo>();

    int contador = 0;



    // Use this for initialization
    void Start()
    {
        createEnviroment = gameObject.GetComponent<CreateEnviroment>();
        matrix =  createEnviroment.GetMatrix();

    }

    public void ResetGraph()
    {
        ResetNodes();
        cola.Clear();
        contador = 0;
    }

    public void ResetNodes()
    {
        for (int f = 0; f < createEnviroment.GetFilas(); f++)
        {

            for (int c = 0; c < createEnviroment.GetColumnas(); c++)
            {
                matrix[f, c].GetComponent<Nodo>().SetVisitado(false);
                matrix[f, c].GetComponent<Nodo>().SetDistancia(100000);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    //Añadir distancia maxima a buscar y hacer un break

    public void BusquedaEnAnchura(Nodo nodo)
    {
        Debug.Log("Entra en la funcion");
        // nodo.visitado = true;
        nodo.SetDistancia(0);

        Debug.Log("distancia primer nodo");


        nodo.SetVisitado(true);
        
        cola.Enqueue(nodo);
        //contador++;
        Debug.Log("encolamos el primer nodo");



        while(cola.Count > 0 && contador <= maxDistancia) //Mientras que no este vacía
        {

            Debug.Log(cola.Count);
            v = cola.Dequeue();


            //vecinos = v.adyacentes;

            foreach( Nodo w in v.adyacentes)
            {
                if(w.GetVisitado() == false)
                {
                    int aux = v.GetDistancia() + 1;
                    if(w.GetDistancia() > aux)
                    {
                        w.SetDistancia(aux);
                    }

                    w.SetVisitado(true);
                    cola.Enqueue(w);
                  
                    

                   // Debug.Log("uno");
                }
            }
            contador++;
            Debug.Log("Contador niveles: " + contador);

        }
       


    }
}
