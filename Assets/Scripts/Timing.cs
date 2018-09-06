﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timing : MonoBehaviour {


    public TextMeshProUGUI timingText;



   public float segundos, segundosFicticios;

   public int minutos, minutosFicticios;
   public int horas, horasFicticios;
   public static int dias, diasFicticios;



    public GameObject shopGameObject;
    private Shop shop;
    private List<StructureBlueprint> lista;


    // Use this for initialization
    void Start () {


        segundos = 0f;

        minutos = 0;
        horas = 0;
        dias = 0;

        shop = shopGameObject.GetComponent<Shop>();
        lista = shop.TypesStructure();

        
    }

    public void UpdateText()
    {

        timingText.text = "Días " + diasFicticios + " - " + horasFicticios + " : " + minutosFicticios + " : " + (int) segundosFicticios; 

    }

    /* public int GetDias()
    {
        return diasFicticios;
    }*/

    // Update is called once per frame
    void Update () {


        segundos += Time.deltaTime;

        segundosFicticios = segundos * 20;


        if(segundosFicticios > 59f)
        {
            segundosFicticios = 0;
            minutosFicticios++;
            segundos = 0;
        }

        if(minutosFicticios > 59)
        {
            minutosFicticios = 0;
            horasFicticios++;
        }

        if(horasFicticios > 23)
        {
            horasFicticios = 0;
            diasFicticios++;


            for(int i = 0; i < lista.Count; i++)
            {
                PlayerStats.Money +=  lista[i].cantidadEdificios * lista[i].cantidadDineroPorDia;
            }
           

        }

        

        if(segundos > 59f)
        {
            segundos = 0;
            minutos++;
        }
        if (minutos > 59)
        {
            minutos = 0;
            horas++;
        }
        if (horas > 23)
        {
            horas = 0;
            dias++;
        }

        UpdateText();
	}
}
