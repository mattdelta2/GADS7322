using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public float WaterAmount = 50f;
    private bool isWatering = false;

    // Create a list to hold references to plants
    private List<Plant> plants = new List<Plant>();

    public bool IsWatering // Renamed from IsWatering to avoid conflict
    {
        get { return isWatering; } // Note the lowercase 'isWatering'
        set { isWatering = value; } // Note the lowercase 'isWatering'
    }

    public void AddPlant(Plant plant)
    {
        Debug.Log("Plant Added");
        // Add the plant to the list
        plants.Add(plant);
    }

    public void StartWatering()
    {
        Debug.Log("Started Watering");
        isWatering = true;

        // Iterate through the list of plants and water each one
        foreach (Plant plant in plants)
        {
            plant.WaterPlant(WaterAmount);
        }
    }

    public void StopWatering()
    {
        Debug.Log("Stopped Watering");
        isWatering = false;
    }
}
