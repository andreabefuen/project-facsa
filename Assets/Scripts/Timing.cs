using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timing : MonoBehaviour {


    public TextMeshProUGUI timingText;



   public float segundos, segundosFicticios;

   public int minutos, minutosFicticios;
   public int horas, horasFicticios;
   public int dias, diasFicticios;
                          
	// Use this for initialization
	void Start () {


        segundos = 0f;

        minutos = 0;
        horas = 0;
        dias = 0;


    }

    public void UpdateText()
    {

        timingText.text = "Días " + diasFicticios + " - " + horasFicticios + " : " + minutosFicticios + " : " + (int) segundosFicticios; 

    }

    // Update is called once per frame
    void Update () {


        segundos += Time.deltaTime;

        segundosFicticios = segundos * 10;


        if(segundosFicticios > 60f)
        {
            segundosFicticios = 0;
            minutosFicticios++;
        }

        if(minutosFicticios > 60)
        {
            minutosFicticios = 0;
            horasFicticios++;
        }

        if(horasFicticios > 24)
        {
            horasFicticios = 0;
            diasFicticios++;
        }

        

        if(segundos > 60f)
        {
            segundos = 0;
            minutos++;
        }
        if (minutos > 60)
        {
            minutos = 0;
            horas++;
        }
        if (horas > 24)
        {
            horas = 0;
            dias++;
        }

        UpdateText();
	}
}
