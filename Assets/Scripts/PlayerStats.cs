using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 10000;

    public static int cantStandardStructure;
    public static int cantStructureFacsa;


    // Use this for initialization
    void Start () {


        Money = startMoney;

        cantStructureFacsa = 0;
        cantStandardStructure = 0;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
