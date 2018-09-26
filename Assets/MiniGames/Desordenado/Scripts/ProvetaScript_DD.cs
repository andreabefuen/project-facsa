using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvetaScript_DD : MonoBehaviour {

    public GameObject GameOverObj;
    public GameObject WinObj;
    public GameObject Fail;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;
    public AudioClip WinClip;
    public AudioClip GameOverClip;
    public Color WaterColor;
    public Color OilColor;
    public Color AlcoholColor;
    public Color HoneyColor;
    public Color SoapColor;
    AudioSource Music;
    SpriteRenderer firstRend;
    SpriteRenderer SecondRend;
    SpriteRenderer ThirdRend;
    SpriteRenderer FourthRend;
    SpriteRenderer FifthRend;
    string[] ElementsInTube;
    int numElements = 1;

    // Use this for initialization
    private void Start()
    {
        Music = GetComponent<AudioSource>();
        Fail.SetActive(false);
        WinObj.SetActive(false);
        GameOverObj.SetActive(false);
        ElementsInTube = new string[5];
        firstRend = first.GetComponent<SpriteRenderer>();
        SecondRend = second.GetComponent<SpriteRenderer>();
        ThirdRend= third.GetComponent<SpriteRenderer>();
        FourthRend = fourth.GetComponent<SpriteRenderer>();
        FifthRend = fifth.GetComponent<SpriteRenderer>();

    }

    public void newElement(string element)
    {
        //Debug.Log(element);
        switch (numElements)
        {//Comprueba y su esta correcto pinta el elemento
            case 1:
                firstRend.color = WhatColor(element);
                ElementsInTube[0] = element;
                numElements++;
                break;
            case 2:
                if (Comprobar(element))
                {
                    SecondRend.color = WhatColor(element);
                    ElementsInTube[1] = element;
                    numElements++;
                }
                else
                {
                    StartCoroutine(GameOver());
                }
                break;
            case 3:
                if (Comprobar(element))
                {
                    ThirdRend.color = WhatColor(element);
                    ElementsInTube[2] = element;
                    numElements++;
                }
                else
                {
                    StartCoroutine(GameOver());
                }
                break;
            case 4:
                if (Comprobar(element))
                {
                    Comprobar(element);
                    FourthRend.color = WhatColor(element);
                    ElementsInTube[3] = element;
                    numElements++;
                }
                else
                {
                    StartCoroutine(GameOver());
                }
                break;
            case 5:
                if (Comprobar(element))
                {
                    FifthRend.color = WhatColor(element);
                    ElementsInTube[4] = element;
                    Win();
                }
                else
                {
                    StartCoroutine(GameOver());
                }
                break;
        }
        
    }
    Color WhatColor(string element)
    {//devuelve el color del objeto element
        if(element == "Oil") return OilColor;
        else if (element == "Water") return WaterColor;
        else if (element == "Soap") return SoapColor;
        else if (element == "Alcohol") return AlcoholColor;
        else if (element == "Honey") return HoneyColor;
        else return new Color(0, 0, 0, 0);

    }

    bool Comprobar(string element)
    {
        if (ElementsInTube.Length > 0)
        {//comprueba si estan en orden si no false
            if (element == "Oil")
            {
                if (System.Array.IndexOf(ElementsInTube, "Alcohol") != -1)
                {
                    //Debug.Log("Desborda");
                    return false;
                }
            }
            else if (element == "Water")
            {
                if (System.Array.IndexOf(ElementsInTube, "Alcohol") != -1 || System.Array.IndexOf(ElementsInTube, "Oil") != -1)
                {
                    //Debug.Log("Desborda");
                    return false;
                }
            }
            else if (element == "Soap")
            {
                if (System.Array.IndexOf(ElementsInTube, "Alcohol") != -1 || System.Array.IndexOf(ElementsInTube, "Oil") != -1 || System.Array.IndexOf(ElementsInTube, "Water") != -1)
                {
                    //Debug.Log("Desborda");
                    return false;
                }
            }
            else if (element == "Honey")
            {
                if (System.Array.IndexOf(ElementsInTube, "Alcohol") != -1 || System.Array.IndexOf(ElementsInTube, "Oil") != -1 || System.Array.IndexOf(ElementsInTube, "Water") != -1 || System.Array.IndexOf(ElementsInTube, "Soap") != -1)
                {
                   // Debug.Log("Desborda");
                    return false;
                }
            }
        }
        return true;
        
    }
    IEnumerator GameOver()
    {//fin de la partida
        Music.loop = false;
        Music.clip = GameOverClip;
        Music.Play();
        //destruye los objetos innecesarios
        GameObject[] Elements;
        Elements = GameObject.FindGameObjectsWithTag("Objects");
        foreach (GameObject objeto in Elements)
        {
            Destroy(objeto);
        }
        bool failActive = true;
        for(int i = 0; i < 30; i++)
        {
            Fail.SetActive(failActive);
            yield return new WaitForSeconds(0.1f);
            failActive = !failActive;
        }
        
        GameOverObj.SetActive(true);

    }
    void Win()
    {//ganado
        Music.loop = false;
        Music.clip = WinClip;
        Music.Play();
        WinObj.SetActive(true);

    }
}
