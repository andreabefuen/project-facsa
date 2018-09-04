using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript_TFQ : MonoBehaviour {

    public GameObject Element1;
    public GameObject Element2;
    public GameObject Panel;
    public GameObject WinPanel;
    public AudioClip WinSound;
    AudioSource Music;
    string[] elements;
    int elemInArray;
	// Use this for initialization
	void Start () {
        Music = GetComponent<AudioSource>();
        elements = new string[20];
        elemInArray = 0;
        Spawn();

    }
    void Spawn()
    {
        int num_elem1 = 0;
        int num_elem2 = 0;
        for(int i = 0; i < 20; i++)
        {
            if(num_elem1 >= 10)
            {
                GameObject newElem = Instantiate(Element2, Element2.transform.position, Element2.transform.rotation);
                newElem.transform.SetParent(Panel.transform);
                newElem.GetComponent<SelectScript_TFQ>().pos = i;
                num_elem2 += 1;
            }
            else if (num_elem2 >= 10)
            {
                GameObject newElem = Instantiate(Element1, Element1.transform.position, Element1.transform.rotation);
                newElem.transform.SetParent(Panel.transform);
                newElem.GetComponent<SelectScript_TFQ>().pos = i;
                num_elem1 += 1;
            }
            else
            {
                int rand = UnityEngine.Random.Range(0, 2);
                if(rand == 1)
                {
                    GameObject newElem = Instantiate(Element1, Element1.transform.position, Element1.transform.rotation);
                    newElem.transform.SetParent(Panel.transform);
                    newElem.GetComponent<SelectScript_TFQ>().pos = i;
                    num_elem1 += 1;
                }
                else
                {
                    GameObject newElem = Instantiate(Element2, Element2.transform.position, Element2.transform.rotation);
                    newElem.transform.SetParent(Panel.transform);
                    newElem.GetComponent<SelectScript_TFQ>().pos = i;
                    num_elem2 += 1;
                }
                
            }
        }

    }

    public void AddArray(int pos, string type) {

        elements[pos] = type;
        elemInArray++;
        if (elemInArray == 10) {
            Comprobar();
        }
    }
    public void RemoveArray(int pos)
    {
        elements[pos] = null;
        elemInArray--;
        if (elemInArray == 10)
        {
            Comprobar();
        }
    }
    void Comprobar()
    {
        Debug.Log("Comprobando");
        int contador = 0;
        for(int i = 0; i < 20; i++)
        {

            if (elements[i] == "Element1")
            {
                contador += 1;
            }
        }

        if(contador == 10)
        {
            Win();
        }
    }
    void Win()
    {
        WinPanel.SetActive(true);
        Music.Stop();
        Music.loop = false;
        Music.clip = WinSound;
        Music.Play();
        GameObject[] elements = GameObject.FindGameObjectsWithTag("Element1");
        foreach(GameObject element in elements)
        {
            Destroy(element);
        }
        elements = GameObject.FindGameObjectsWithTag("Element2");
        foreach (GameObject element in elements)
        {
            Destroy(element);
        }
    }
}
