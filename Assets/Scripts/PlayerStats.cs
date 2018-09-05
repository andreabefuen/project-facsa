using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int money;
    public int startMoney = 10000;

    public int cantStandardStructure;
    public int cantStructureFacsa;


    // Use this for initialization
    void Start () {


        money = startMoney;

        cantStructureFacsa = 0;
        cantStandardStructure = 0;
    }


    public int GetMoney()
    {
        return money;
    }

    public void moreMoney(int plus)
    {
        money += plus;
    }

    public void reduceMoney(int minus)
    {
        money -= minus;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
