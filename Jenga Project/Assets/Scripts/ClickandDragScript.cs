using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandDragScript : MonoBehaviour
{
    private Vector3 offset;

    private Vector3 screenPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("dragging");

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position -
                 //Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                 Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
    }

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = //new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPos;
    }
}
