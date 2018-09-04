using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone_OD : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable_OD d = eventData.pointerDrag.GetComponent<Draggable_OD>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable_OD d = eventData.pointerDrag.GetComponent<Draggable_OD>();
        if (d != null && d.placeholderParent == this.transform) 
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }


	public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " esta en " + gameObject.name);
        Draggable_OD d = eventData.pointerDrag.GetComponent<Draggable_OD>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

    }
}
