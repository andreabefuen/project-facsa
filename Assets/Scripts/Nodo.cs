using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nodo : MonoBehaviour {



    public List<Nodo> adyacentes;

    public Text positionText;

    private bool visitado;
    
    [SerializeField] private int distancia;

	// Use this for initialization
	void Start () {
        distancia = 10000;
        visitado = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public int GetDistancia()
    {
        return distancia;
    
    }

    public void SetDistancia(int dist)
    {
        distancia = dist;
    }

    public void SetVisitado(bool visit)
    {
        visitado = visit;
    }

    public bool GetVisitado()
    {
        return visitado;
    }
}
