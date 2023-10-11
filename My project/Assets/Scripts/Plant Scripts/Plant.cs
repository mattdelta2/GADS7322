using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Plant : MonoBehaviour
{
    public int maxWater = 100; // Maximum water the plant can hold.
    public int currentWater = 0; // Current water level of the plant.
    public float growthRate = 0.01f; // Rate at which the plant grows.

    public GameObject seedlingSprite; // Reference to the seedling sprite.
    public GameObject matureSprite; // Reference to the mature plant sprite.
    public GameObject floweringSprite; // Reference to the flowering plant sprite.

    private PlantState currentState;

    private enum PlantState
    {
        Seedling,
        Mature,
        Flowering
    }



    void Start()
    {
        currentState = PlantState.Seedling;
        UpdatePlantAppearance();

    }


    void Update()
    {
        // Check if the plant has enough water to grow.
        if (currentWater >= maxWater)
        {
            Grow();
        }
    }

    public void WaterPlant(int waterAmount)
    {
        currentWater += waterAmount;
        // Clamp the current water level to not exceed the maximum.
        currentWater = Mathf.Clamp(currentWater, 0, maxWater);
    }


    private void Grow()
    {
        switch (currentState)
        {
            case PlantState.Seedling:
                currentState = PlantState.Mature;
                break;
            case PlantState.Mature:
                currentState = PlantState.Flowering;
                break;
            case PlantState.Flowering:
                // The plant has reached the final stage.
                break;
        }

        currentWater = 0; // Reset the water level after growing.
        UpdatePlantAppearance();

    }


    private void UpdatePlantAppearance()
    {
        // Set the active sprite based on the current growth stage.
        seedlingSprite.SetActive(currentState == PlantState.Seedling);
        matureSprite.SetActive(currentState == PlantState.Mature);
        floweringSprite.SetActive(currentState == PlantState.Flowering);
    }
}
