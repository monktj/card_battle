﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDragListener 
{
    /// <summary>
    /// When dragging started, All 'DropZone' are filtered and inactived by this condition.
    /// </summary>
    bool CanDroppable(DropZone dropZone);

    void OnDragStarted(PointerEventData eventData);
    void OnDroped(PointerEventData eventData, DropZone dropZone);
    void OnDragCanceled(PointerEventData eventData,DraggableUI.SavedTransform preTransform);
}