using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public float closedWaterDrainRate = 0.5f;
    public float openWaterDrainRate = 0.3f;

    private bool isOpen = false;

    private void Start()
    {
        AdjustWaterDrainRate();
    }

    public void ToggleWindow()
    {
        isOpen = !isOpen;
        AdjustWaterDrainRate();
    }

    private void AdjustWaterDrainRate()
    {
        float newWaterDrainRate = isOpen ? openWaterDrainRate : closedWaterDrainRate;

        // Update the water drain rate globally (e.g., in your GameManager or WateringCan script)
        //GameManager.Instance.UpdateWaterDrainRate(newWaterDrainRate);
    }
}
