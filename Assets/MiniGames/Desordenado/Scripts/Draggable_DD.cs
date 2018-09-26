using System.Collections;
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
        if (Manager_DD.InGame)
        {
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("OnDrag");
        if (Manager_DD.InGame)
        {
            this.transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Sound.clip = DropSound;
        //Sound.Play();
        if (Manager_DD.InGame)
        {
            this.transform.SetParent(parentToReturnTo);

            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if (parentToReturnTo.gameObject.name == "PanelProveta")
            {//Si el objeto donde lo sueltas es la proveta destruye y lo añade en la proveta
                //comprobar los elementos
                Proveta.GetComponent<ProvetaScript_DD>().newElement(this.gameObject.name);
                Destroy(gameObject);
            }
            // Debug.Log("OnEndDrag");
        }
    }

}
