using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDragListener {
    public bool CanDroppable(DropZone dropZone) {
        return dropZone.name == "MyGround";
    }

    public void OnDragCanceled(PointerEventData eventData, DraggableUI.SavedTransform preTransform) {
        GetComponent<DraggableUI>().ResetPosition();
    }

    public void OnDragStarted(PointerEventData eventData) {
    }

    public void OnDroped(PointerEventData eventData, DropZone dropZone) {
        Debug.Log("DropSuccess " + dropZone.name);
        GetComponent<DraggableUI>().ResetPosition();
    }
}
