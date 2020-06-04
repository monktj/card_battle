using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDragListener 
{
    /// <summary>
    /// When dragging started, All 'DropZone' are filtered and inactived by this condition.
    /// </summary>
    bool CanDroppable(DropZone dropZone);

    void OnDragStarted(DraggableUI draggable,PointerEventData eventData);
    void OnDragging(DraggableUI draggable, PointerEventData eventData);
    void OnDroped(DraggableUI draggable, PointerEventData eventData, DropZone dropZone);
    void OnDragCanceled(DraggableUI draggable, PointerEventData eventData);
}
