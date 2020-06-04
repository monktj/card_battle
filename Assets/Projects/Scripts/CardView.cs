using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IDragListener {
    private Color preColor;

    public bool CanDroppable(DropZone dropZone) {
        return dropZone.name.Contains("Ground");
    }

    void Start() {
        preColor = GetComponent<Image>().color;
    }

   

    public void OnDragStarted(DraggableUI draggable,PointerEventData eventData) {
    }
    public void OnDragging(DraggableUI draggable, PointerEventData eventData) {
        var dropZone=draggable.FindDropZone(eventData);
        if (dropZone==null) {
            GetComponent<Image>().color = preColor;
            
        } else {
            if (dropZone.name=="MyGround") {
                GetComponent<Image>().color = Color.green;
            } else if (dropZone.name=="EnemyGround") {
                GetComponent<Image>().color = Color.red;
            }
        }
    }
    public void OnDragCanceled(DraggableUI draggable, PointerEventData eventData) {
        draggable.ResetPosition(draggable.preTransform);
        GetComponent<Image>().color = preColor;
    }

    public void OnDroped(DraggableUI draggable, PointerEventData eventData, DropZone dropZone) {
        Debug.Log("DropSuccess " + dropZone.name);
        draggable.ResetPosition(draggable.preTransform);
        GetComponent<Image>().color = preColor;
    }
}
