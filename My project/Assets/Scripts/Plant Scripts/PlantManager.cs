using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public GameObject[] plants; // An array of plant GameObjects.
    public GameObject[] fixedPositions; // An array of fixed position GameObjects.

    private bool isPlacingPlant = false;
    private GameObject selectedPlant;
    private GameObject selectedPosition;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1)) // Detect Right mouse click.
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Plant position: " + transform.position);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (isPlacingPlant)
                {
                    // If we're in "placing plant" mode, handle the selection of a fixed position.
                    if (IsFixedPosition(clickedObject))
                    {
                        PlacePlantAtPosition(selectedPlant, clickedObject);
                        isPlacingPlant = false;
                    }
                }
                else
                {
                    // If not in "placing plant" mode, check if a plant was clicked.
                    if (IsPlant(clickedObject))
                    {
                        selectedPlant = clickedObject;
                        isPlacingPlant = true;
                    }
                }
            }
        }
    }

    bool IsPlant(GameObject obj)
    {
        // Check if the GameObject is a plant. Adjust the criteria based on your setup.
        return obj.CompareTag("Plant");
    }

    bool IsFixedPosition(GameObject obj)
    {
        // Check if the GameObject is a fixed position. Adjust the criteria based on your setup.
        return obj.CompareTag("FixedPosition");
    }

    void PlacePlantAtPosition(GameObject plant, GameObject position)
    {
        // Move the selected plant to the selected fixed position.
        Plant plantScript = plant.GetComponent<Plant>();
        Vector2 targetPosition = position.transform.position; // Ensure to use Vector2 for 2D games.
        plantScript.MoveToTargetPosition(targetPosition);
    }
}
