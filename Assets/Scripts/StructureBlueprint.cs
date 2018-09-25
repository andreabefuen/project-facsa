using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class StructureBlueprint {


    public GameObject prefab;

    public int cost;

    public int moneyOfDemolition;


    //Variables de cada edificio

    public int cantidadDineroPorDia;

    public int tiempoEstropearseDias;

    public int cantidadEdificios;

    public bool needWater;

    public int levelOfSatisfaction;

    public bool isAStreet;


    public Building nodeAsociate;
}
