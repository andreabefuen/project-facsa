using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone_DB : MonoBehaviour, IDropHandler {

	public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " esta en " + gameObject.name);
        Draggable_DB d = eventData.pointerDrag.GetComponent<Draggable_DB>();
        Destroy(eventData.pointerDrag);
        
    }
}
