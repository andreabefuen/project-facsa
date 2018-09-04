using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript_FIL : MonoBehaviour {

    public GameObject[] Cards;

    public GameObject Panel;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public AudioClip WinSound;
    public AudioClip GameoverSound;
    public int level;
    AudioSource Music;
    GameObject Select1;
    GameObject Select2;
    int aciertos;
    bool win, GameOverBool;
    float timer;
    public Text TimeText;
	// Use this for initialization
	void Start () {
        Music = GetComponent<AudioSource>();
        Spawn();
        aciertos = 0;
        timer = 60f;
        win = false;
        GameOverBool = false;
    }
    void Update()
    {
        if (!win && !GameOverBool)
        {
            timer -= Time.deltaTime;
            int seconds = (int)timer % 60;
            int min = (int)timer / 60;

            TimeText.text = "Time: " + min.ToString("00") + ":" + seconds.ToString("00");
            if (timer <= 0)
            {
                GameOverBool = true;
                TimeText.text = "Time: 00:00";
                GameOver();
            }
        }
    }
    void Spawn()
    {
        int cardsInTable = 0;
        while(cardsInTable < 20 ){

            int rand = UnityEngine.Random.Range(0, Cards.Length);
            if (Cards[rand] != null)
            {
                GameObject newElem = Instantiate(Cards[rand], Cards[rand].transform.position, Cards[rand].transform.rotation);
                newElem.transform.SetParent(Panel.transform);
                Cards[rand] = null;
                cardsInTable++;
            }
        }

    }

    public void Select(GameObject Card) {

       if(Select1 == null)
        {
            Select1 = Card;
        }
        else if(Select2 == null)
        {
            Select2 = Card;
            Comprobar();

        }
        else
        {
            if (level == 1)
            {
                Card.GetComponent<SelectScript_FIL>().DesSelect();
            }
            else { Card.GetComponent<SelectScript2_FIL>().DesSelect(); }
        }
    }
  
    void Comprobar()
    {
        if (level == 1)
        {
            SelectScript_FIL Script1 = Select1.GetComponent<SelectScript_FIL>();
            SelectScript_FIL Script2 = Select2.GetComponent<SelectScript_FIL>();
            if (Script1.type == Script2.type)
            {
                Script1.Correct();
                Script2.Correct();
                Select1 = null;
                Select2 = null;
                timer += 15;
                aciertos++;
                if (aciertos == 10) Win();
            }
            else
            {
                timer -= 5;
                Script1.DesSelect();
                Script2.DesSelect();
                Select1 = null;
                Select2 = null;
            }
        }
        else if (level == 2)
        {
            SelectScript2_FIL Script1 = Select1.GetComponent<SelectScript2_FIL>();
            SelectScript2_FIL Script2 = Select2.GetComponent<SelectScript2_FIL>();
            if (Script1.type == Script2.type)
            {
                Script1.Correct();
                Script2.Correct();
                Select1 = null;
                Select2 = null;
                timer += 15;
                aciertos++;
                if (aciertos == 10) Win();
            }
            else
            {
                StartCoroutine(Fail(Script1, Script2));
            }
        }

        
    }
    void Win()
    {
        win = true;
        WinPanel.SetActive(true);
        Music.Stop();
        Music.loop = false;
        Music.clip = WinSound;
        Music.Play();
    }
    void GameOver()
    {
        GameOverPanel.SetActive(true);
        Music.Stop();
        Music.loop = false;
        Music.clip = GameoverSound;
        Music.Play();
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject element in Cards)
        {
            Destroy(element);
        }

    }

    IEnumerator Fail(SelectScript2_FIL Script1, SelectScript2_FIL Script2 )
    {
        yield return new WaitForSeconds(1f);
        timer -= 5;
        Script1.DesSelect();
        Script2.DesSelect();
        Select1 = null;
        Select2 = null;
    }
}
