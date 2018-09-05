﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_DD : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    public GameObject Proveta;
    public AudioClip DragSound;
    public AudioClip DropSound;
    AudioSource Sound;

    GameObject placeholder = null;

    void Start()
    {
        Sound = gameObject.GetComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Sound.clip = DragSound;
        //Sound.Play();
        //Debug.Log("OnBeginDrag");

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }
    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("OnDrag");
        this.transform.position = eventData.position;

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Sound.clip = DropSound;
        //Sound.Play();
        this.transform.SetParent(parentToReturnTo);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (parentToReturnTo.gameObject.name == "PanelProveta")
        {
            //comprobar los elementos
            Proveta.GetComponent<ProvetaScript_DD>().newElement(this.gameObject.name);
            Destroy(gameObject);
        }
       // Debug.Log("OnEndDrag");
    }

}