using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


[RequireComponent(typeof(CanvasGroup),typeof(IDragListener))]
public class DraggableUI : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Vector3 dampingScale = Vector3.one;

    public struct SavedTransform {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }
    /// <summary>
    /// When dragging starts, transform value is saved.
    /// </summary>
    public SavedTransform? preTransform = null;

    private IDragListener dragListener;

    void Start() {
        dragListener = GetComponent<IDragListener>();
        if (dragListener == null) {
            throw new Exception("Drag Listener was not found.");
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        //Previous transform value save
        var savedTr= new SavedTransform();
        savedTr.position= transform.position;
        savedTr.rotation = transform.rotation;
        savedTr.scale = transform.localScale;
        preTransform = savedTr;

        //Drag dampping scale effect
        transform.localScale = Vector3.Scale(transform.localScale,dampingScale);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

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

            dragListener.OnDragCanceled(eventData,preTransform.Value);
        }
    }

    public void ResetPosition() {
        transform.position = preTransform.Value.position;
        transform.rotation = preTransform.Value.rotation;
        transform.localScale = preTransform.Value.scale;
    }

}

