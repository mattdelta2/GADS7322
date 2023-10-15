using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1)) // Check for right mouse button click.
        {
            // Calculate the offset from the mouse position to the object's position.
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;

            Debug.Log("Drag started for " + gameObject.name);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        Debug.Log("Drag stopped for " + gameObject.name);
    }

    private void Update()
    {
        if (isDragging)
        {
            // Update the object's position based on the mouse position.
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;

            Debug.Log("Position while dragging " + gameObject.name + ": " + transform.position);
        }
    }
}


