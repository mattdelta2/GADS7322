using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public Vector2 minXMax = new Vector2(0, 10); // Define the minimum and maximum X-axis values.
    public Vector2 minYMax = new Vector2(0, 10); // Define the minimum and maximum Y-axis values.

    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 offset = lastMousePosition - Input.mousePosition;
            Vector3 newPosition = transform.position + new Vector3(offset.x * panSpeed * Time.deltaTime, offset.y * panSpeed * Time.deltaTime, 0);

            // Clamp the camera's X and Y positions within the specified ranges.
            newPosition.x = Mathf.Clamp(newPosition.x, minXMax.x, minXMax.y);
            newPosition.y = Mathf.Clamp(newPosition.y, minYMax.x, minYMax.y);

            transform.position = newPosition;
            lastMousePosition = Input.mousePosition;
        }
    }
}
