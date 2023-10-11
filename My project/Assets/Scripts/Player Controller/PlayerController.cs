using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int wateringResource = 100; // Initial watering resource for the player.
    public float wateringCooldown = 1.0f; // Cooldown between watering actions.
    private float nextWateringTime;

    private void Update()
    {
        if (Time.time >= nextWateringTime && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Plant plant = hit.collider.GetComponent<Plant>();
                if (plant != null && wateringResource > 0)
                {
                    // Water the plant and deduct from the watering resource.
                    plant.WaterPlant(10); // Adjust the amount as needed.
                    wateringResource -= 10;
                    nextWateringTime = Time.time + wateringCooldown; // Apply cooldown.
                    // Add visual feedback here (e.g., particle effect).
                }
            }
        }
    }
}
