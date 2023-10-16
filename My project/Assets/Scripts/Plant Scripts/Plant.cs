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

    //Movement Variables
    public Vector2 targetPosition;
    private bool isMoving = false;
    private float moveSpeed = 5f;

    //Room boundries

    public float roomMinX;
    public float roomMaxX;
    public float roomMinY;
    public float roomMaxY;

    //Adding watering can
    private WateringCan wateringCan;

    //Adding Animator
    private Animator animator;

    private void Start()
    {
        wateringCan = FindObjectOfType<WateringCan>();

        wateringCan.AddPlant(this);

        animator = GetComponent<Animator>();
    }




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

        if(isMoving)
        {
            //move plant towards new position
            Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed*  Time.deltaTime);

            //check to see if the position is in the same room as the plant
            newPosition.x = Mathf.Clamp(newPosition.x, roomMinX, roomMaxX);
            newPosition.y = Mathf.Clamp(newPosition.y, roomMinY, roomMaxY);


            //checks if plant has reached position
            if((Vector2)transform.position == targetPosition)
            {
                isMoving = false;
            }
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
        animator.SetBool("IsHappy", isHappy);


        if(!isHappy)
        {
            AudioSource audioSource  = GetComponent<AudioSource>();

            if(audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
        
    }

    public void MoveToTargetPosition(Vector2 target)
    {
        targetPosition = target;
        isMoving = true;
        Debug.Log("Moving to target: " + target);
    }


}
