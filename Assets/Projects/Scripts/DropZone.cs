using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum DropZoneType {
    None=0,
    MyGround,
    EnemyGround,
}

public class DropZone : MonoBehaviour
{
    public DropZoneType zoneType;
}
