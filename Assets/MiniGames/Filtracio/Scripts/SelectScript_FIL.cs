using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript_FIL : MonoBehaviour {
    public GameObject manager;
    public Outline Aura;
    public AudioClip SelecClip;
    public AudioClip DeselecClip;
    public AudioClip CorrectClip;
    public int type;
    AudioSource Sound;
    bool selected;
    ManagerScript_FIL managerSc;

    // Use this for initialization

    private void Start()
    {
        selected = false;
        Sound = GetComponent<AudioSource>();
        manager = GameObject.Find("Manager");
        managerSc = manager.GetComponent<ManagerScript_FIL>();
    }
    // Update is called once per frame
    public void Select () {
        Debug.Log(selected);
		if (!selected)
        {
            Sound.clip = SelecClip;
            Sound.Play();
            selected = true;
            Aura.enabled = true;
            managerSc.Select(this.gameObject);

        }
        /*else
        {
            DesSelect();
        }*/

    }
    public void DesSelect()
    {
        Sound.clip = DeselecClip;
        Sound.Play();
        selected = false;
        Aura.enabled = false;

    }
    public void Correct()
    {
        Sound.clip = CorrectClip;
        Sound.Play();
        Aura.effectColor = new Color32(0,255,0,255);
    }
}
