using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWatering : MonoBehaviour
{
    public WateringCan wateringCan;

    private void Update()
    {
        // Check if the player has clicked on the watering can button.
        if (wateringCan.IsWatering)
        {
            // Check if the player has clicked on a plant.
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Plant plant = hit.collider.GetComponent<Plant>();

                    if (plant != null)
                    {
                        // Increase the water level of the plant.
                        plant.WaterPlant(wateringCan.WaterAmount);
                    }
                }
            }
        }
    }
}
