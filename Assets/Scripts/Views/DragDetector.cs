using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class DragDetector : View
{
    [SerializeField]
    private int _blockSlotIndex;

    public static event Action<int> DragStarted;
    public static event Action<int> DragEnded;

    private bool _dragging;

    private void OnMouseDown()
    {
        _dragging = true;
        Debug.Log("OnMouseDown " + _blockSlotIndex);
        if (DragStarted != null)
        {
            DragStarted(_blockSlotIndex);
        }
    }

    private void OnMouseUp()
    {        
        _dragging = false;
        Debug.Log("OnMouseUp " + _blockSlotIndex);        
        if (DragEnded != null)
        {
            DragEnded(_blockSlotIndex);
        }
        
        transform.GetChild(0).localPosition = Vector3.zero;
    }

    private void Update()
    {
        if (!_dragging) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.GetChild(0).position = mousePosition;
    }
}
