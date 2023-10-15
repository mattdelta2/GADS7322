using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    
    public float happyThreshold = 50f;
    public float sadThreshold = 20f;

    public SpriteRenderer plantRenderer;

    public Sprite happySprite;
    public Sprite sadSprite;

    public bool IsInSunlight { get; set; } // A property to determine if the plant is in sunlight or shade.

    public float waterLevel = 100f;
    public float waterDrainRate = 0.5f;

    private bool isHappy = true;




    void Update()
    {
        waterLevel -= waterDrainRate * Time.deltaTime;
        if (waterLevel <= sadThreshold && isHappy)
        {
            ChangePlantState(false);
           // waterLevel -= waterDrainRate * Time.deltaTime;
        }
        else if (waterLevel >= happyThreshold && !isHappy)
        {
            ChangePlantState(true);
            //waterLevel -= waterDrainRate * Time.deltaTime;
        }
        if(waterLevel <= 0)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("End Scene");
        }
    }

    public void WaterPlant(float waterAmount)
    {
        waterLevel += waterAmount;
        waterLevel = Mathf.Clamp(waterLevel, 0f, 100f);
    }

    private void ChangePlantState(bool happy)
    {
        isHappy = happy;

        plantRenderer.sprite = isHappy ? happySprite : sadSprite;
        
    }


}
