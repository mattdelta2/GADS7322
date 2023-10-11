using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject[] plantPrefabs; // Array of different plant prefabs.
    public Transform spawnPoint; // Where you want to spawn the plant.

    void Start()
    {
        // Instantiate a specific plant prefab with its unique properties.
        GameObject newPlant = Instantiate(plantPrefabs[0], spawnPoint.position, Quaternion.identity);

        // Access and display the customized properties.
        Plant plantScript = newPlant.GetComponent<Plant>();
        Debug.Log("Plant Name: " + plantScript.plantName);
        Debug.Log("Max Water: " + plantScript.maxWater);
        Debug.Log("Growth Rate: " + plantScript.growthRate);
    }


}
