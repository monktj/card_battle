using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class DropZone : MonoBehaviour
{
    private void Start() {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
