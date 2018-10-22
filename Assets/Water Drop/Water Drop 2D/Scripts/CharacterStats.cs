using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int lifes;

    public TextMeshProUGUI text;

    private void Awake()
    {
        text = text.GetComponent<TextMeshProUGUI>();
        text.text = "LIVES: " + lifes.ToString();
    }

    public int GetLifes()
    {
        return lifes;
    }

    public void SetLifes(int l)
    {
        lifes = l;
        text.text = "LIVES: " + lifes.ToString();
    }

}
