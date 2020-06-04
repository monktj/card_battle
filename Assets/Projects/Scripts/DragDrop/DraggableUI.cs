using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


[RequireComponent(typeof(CanvasGroup),typeof(IDragListener))]
public class DraggableUI : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public bool isDragging = false;
    public Vector3 dampingScale = Vector3.one;

    public class SavedTransform {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public Transform parent;
        public int siblingIndex;
    }
    /// <summary>
    /// When dragging starts, transform value is saved.
    /// </summary>
    public SavedTransform preTransform = new SavedTransform();

    private IDragListener dragListener;

    void Start() {
        isDragging = false;
        dragListener = GetComponent<IDragListener>();
        if (dragListener == null) {
            throw new Exception("Drag Listener was not found.");
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        isDragging = true;

        //Previous transform value save
        preTransform.position= transform.position;
        preTransform.rotation = transform.rotation;
        preTransform.scale = transform.localScale;
        preTransform.parent = transform.parent;
        preTransform.siblingIndex = transform.GetSiblingIndex();

        //Drag 
        transform.localScale = Vector3.Scale(transform.localScale,dampingScale);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(GetComponentInParent<Canvas>().transform, false);
        transform.SetAsLastSibling();

        //DropZones Set Active
        var dropZones=FindObjectsOfType<DropZone>();
        foreach (var zone in dropZones) {
            zone.GetComponent<CanvasGroup>().blocksRaycasts = dragListener.CanDroppable(zone);
        }

        dragListener.OnDragStarted(eventData);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        DropZone dropZone = null;
        if (results.Count>0) {
            dropZone = results[0].gameObject.GetComponent<DropZone>();
        }

        //'Drop Success' or 'Drag Canceled'
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(dropZone != null) {
            dragListener.OnDroped(eventData, dropZone);
        } else {
            var dropZones = FindObjectsOfType<DropZone>();
            foreach(var zone in dropZones) {
                zone.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }

            dragListener.OnDragCanceled(eventData,preTransform);
        }

        isDragging = false;
    }

    public void ResetPosition() {
        transform.SetParent(preTransform.parent, false);
        transform.SetSiblingIndex(preTransform.siblingIndex);
        transform.position = preTransform.position;
        transform.rotation = preTransform.rotation;
        transform.localScale = preTransform.scale;
    }

}

