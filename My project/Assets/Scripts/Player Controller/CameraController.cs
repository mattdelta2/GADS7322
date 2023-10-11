using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f; // Adjust this value for pan speed.
    private Vector3 lastMousePosition;

    void Update()
    {
        // Camera panning with the mouse.
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 offset = lastMousePosition - Input.mousePosition;
            transform.Translate(offset * panSpeed * Time.deltaTime);
            lastMousePosition = Input.mousePosition;
        }
    }
}
