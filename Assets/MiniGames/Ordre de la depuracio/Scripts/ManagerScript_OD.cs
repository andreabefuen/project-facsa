using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript_OD : MonoBehaviour {

    public GameObject SortZone;
    public GameObject WinText;
    public GameObject Instructions;
    public AudioSource Sound;
    public AudioClip WinClip;
    public AudioClip FailClip;
    public static bool Ingame;
    Transform Sort;

	// Use this for initialization
	void Start () {
        WinText.SetActive(false);
        Sort = SortZone.transform;
        Ingame = false;
	}
	
	// Update is called once per frame

    public void Compare() {
        StartCoroutine(CompareCard());
    }
    IEnumerator CompareCard()
    {//compara si las cartas estan en orden correcto
        yield return new WaitForSeconds(0.1f);
        Debug.Log("comparar :" + Sort.childCount);
        if (Sort.childCount == 7)
        {
            GameObject[] CardList = new GameObject[Sort.childCount];
            for (int i = 0; i < Sort.childCount; i++)
            {
                CardList[i] = Sort.GetChild(i).gameObject;
                //Debug.Log("Carta" + i + " " + CardList[i].name);
            }
            int Correctas = 0;
            if (CardList[0].name == "CardDesbaste(Clone)")
            {
                Correctas += 1;
                //Debug.Log("carta1 = Desbaste");
            }
            if (CardList[1].name == "CardDesarenar(Clone)")
            {
                Correctas += 1;
                //Debug.Log("carta2 = Desarenar");
            }
            if (CardList[2].name == "CardBiologic(Clone)")
            {
                Correctas += 1;
                //Debug.Log("carta3 = Biologic");
            }
            if (CardList[3].name == "CardAireacio(Clone)")
            {
                Correctas += 1;
                //Debug.Log("carta4 = Aireacio");
            }
            if (CardList[4].name == "CardQuimic(Clone)")
            {
                Correctas += 1;
                //Debug.Log("carta5 = FisicQuimic");
            }
            if (CardList[5].name == "CardDesinfeccio(Clone)")
            {
                Correctas += 1;
                //Debug.Log("carta6 = Desinfeccio");
            }
            if (CardList[6].name == "CardFang(Clone)")
            {
                Correctas += 1;
                //Debug.Log("carta7 = Fang");
            }
            Debug.Log(Correctas);
            if(Correctas == 7)
            {
                Win();
            }
            else
            {
                StartCoroutine(Fallo());
            }
        }
    }
    public void StartGame()
    {
        Ingame = true;
        Instructions.SetActive(false);
    }
    void Win()
    {
        Sound.clip = WinClip;
        Sound.Play();
        WinText.SetActive(true);
        GameObject.Find("Ordenado").SetActive(false);
        GameObject.Find("Desordenado").SetActive(false);
        GameObject[] Cartes = GameObject.FindGameObjectsWithTag("Cards");
        foreach (GameObject card in Cartes)
        {
            Destroy(card);
        }
    }
    IEnumerator Fallo()
    {//parpadea si fallas
        Sound.clip = FailClip;
        Sound.Play();
        Image SortImage = Sort.GetComponent<Image>();
        SortImage.color = new Color32(255, 0, 0, 200);

        yield return new WaitForSeconds(0.1f);
        SortImage.color = new Color32(175, 255, 200, 200);

        yield return new WaitForSeconds(0.1f);
        SortImage.color = new Color32(255, 0, 0, 200);

        yield return new WaitForSeconds(0.1f);
        SortImage.color = new Color32(175, 255, 200, 200);

        yield return new WaitForSeconds(0.1f);
        SortImage.color = new Color32(255, 0, 0, 200);

        yield return new WaitForSeconds(0.1f);
        SortImage.color = new Color32(175, 255, 200, 200);

    }
}
