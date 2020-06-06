using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IDragListener {
    [SerializeField]
    public Image iconImage;

    void Start() {
        Refresh(GameDatabase.instance.cards[0]);
    }
    


    public void Refresh(Card card) {
        iconImage.sprite = card.texture;
    }


    #region IDragListener Implementation
    public bool CanDroppable(DropZone dropZone) {
        return dropZone.name.Contains("Ground");
    }
    public void OnDragStarted(DraggableUI draggable,PointerEventData eventData) {
        draggable.DetachFromParent();
    }
    public void OnDragging(DraggableUI draggable, PointerEventData eventData) {
        var dropZone=draggable.GetDropZone(eventData);
    }
    public void OnDragEnded(DraggableUI draggable, PointerEventData eventData,bool isSuccess,DropZone dropZoneOrNull) {
        draggable.ReturnToParent();
        draggable.ResetPosition(draggable.preTransform);
    }
    #endregion
}
