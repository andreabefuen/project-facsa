using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class StreetsBlueprint {

    public GameObject prefab;

    public int cost;

    public int moneyOfDemolition;


    //Variables de cada edificio

    public int cantidadDineroPorDia;

    public int tiempoEstropearseDias;

    public int streetCount;

    public int levelOfSatisfaction;


    public Building nodeAsociate;
}
