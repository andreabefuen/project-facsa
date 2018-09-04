using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone_DD : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable_DD d = eventData.pointerDrag.GetComponent<Draggable_DD>();

    }


	public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " esta en " + gameObject.name);
        Draggable_DD d = eventData.pointerDrag.GetComponent<Draggable_DD>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

    }
}
