using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript_TFQ : MonoBehaviour {
    public GameObject manager;
    public Outline Aura;
    public int pos;
    public AudioClip SelecClip;
    public AudioClip DeselecClip;
    AudioSource Sound;
    bool selected;
    ManagerScript_TFQ managerSc;

    // Use this for initialization

    private void Start()
    {
        selected = false;
        Sound = GetComponent<AudioSource>();
        manager = GameObject.Find("Manager");
        managerSc = manager.GetComponent<ManagerScript_TFQ>();
    }
    // Update is called once per frame
    public void Select () {
        if (managerSc.InGame)
        {
            if (!selected)
            {
                Sound.clip = SelecClip;
                Sound.Play();
                managerSc.AddArray(pos, gameObject.tag);
                selected = true;
                Aura.enabled = true;
            }
            else
            {
                Sound.clip = DeselecClip;
                Sound.Play();
                managerSc.RemoveArray(pos);
                selected = false;
                Aura.enabled = false;
            }
        }
	}
}
