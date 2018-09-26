using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript2_FIL : MonoBehaviour {
    public GameObject manager;
    public Outline Aura;
    public AudioClip SelecClip;
    public AudioClip DeselecClip;
    public AudioClip CorrectClip;
    public Text Texto;
    public Image Imagen;
    public Sprite Trasera;
    public Sprite Frontal;
    public int type;
    public AudioSource Sound;
    bool selected = false;
    ManagerScript_FIL managerSc;

    // Use this for initialization

    private void Start()
    {
        Texto.enabled = false;
        Imagen.sprite = Trasera;
        selected = false;
        manager = GameObject.Find("Manager");
        managerSc = manager.GetComponent<ManagerScript_FIL>();
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    // Variacion de SelectScript_FIL para que gire la carta
    public void Select () {
        //Debug.Log(selected);
		if (!selected)
        {
            Debug.Log("Select");
            Sound.clip = SelecClip;
            Sound.Play();
            selected = true;
            Aura.enabled = true;
            Texto.enabled = true;
            Imagen.sprite = Frontal;
            transform.localScale = new Vector3(0.65f, 0.9f, 1f);
            managerSc.Select(this.gameObject);
        }


    }
    public void DesSelect()
    {
        Texto.enabled = false;
        Imagen.sprite = Trasera;
        transform.localScale = new Vector3(1f, 1f, 1f);
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
