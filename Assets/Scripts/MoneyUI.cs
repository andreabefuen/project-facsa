using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MoneyUI : MonoBehaviour {

    //public TextMeshPro moneyText;
    private TextMeshProUGUI moneyText;


	// Use this for initialization
	void Awake () {
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = "Money";
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "Money: " + PlayerStats.Money.ToString() + " $";

	}
}
