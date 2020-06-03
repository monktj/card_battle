using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

[RequireComponent(typeof(CanvasGroup))]
public class DraggableUI : MonoBehaviour, IDraggable, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public DropZoneType allowZoneType;
    public Vector3 dampingScale = Vector3.one;
    public Action<DropZone> OnDragEnded;

    private Vector3 initPosition;

    void Start() {
        initPosition = transform.position;
    }


    public void OnBeginDrag(PointerEventData eventData) {
        transform.localScale = dampingScale;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        //DropZones Set Active
        var dropZones=FindObjectsOfType<DropZone>();
        foreach (var zone in dropZones) {
            bool isAllowZone = (int)(zone.zoneType & allowZoneType) != 0;
            zone.GetComponent<CanvasGroup>().blocksRaycasts = isAllowZone;
        }
    }

    public void OnDrag(PointerEventData eventData) {

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        //DropZone Check
        if (results.Count>0) {
            var dropZone=results[0].gameObject.GetComponent<DropZone>();
            
            if (dropZone!=null) {
                Debug.Log("Drop "+dropZone.gameObject.name);
                OnDragEnded?.Invoke(dropZone);
            } else {
                DragCancle();
            }
        } else{
            DragCancle();
        }
        
    }

    private void DragCancle() {
        transform.position = initPosition;
        transform.localScale = Vector3.one;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        var dropZones = FindObjectsOfType<DropZone>();
        foreach(var zone in dropZones) {
            zone.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }


}
