using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private GameManager gameManager;

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

    private bool isWindowOpen = false;



    private void Start()
    {
        wateringCan = FindObjectOfType<WateringCan>();

        wateringCan.AddPlant(this);

        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }




    void Update()
    {
        if (isWindowOpen)
        {
            waterLevel -= (waterDrainRate - 2) * Time.deltaTime;
        }
        else
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
            if (waterLevel <= 0)
            {
                
                Time.timeScale = 0f;
                SceneManager.LoadScene("End Scene");
                gameManager.endGame();
            }

            if (isMoving)
            {
                //move plant towards new position
                Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                //check to see if the position is in the same room as the plant
                newPosition.x = Mathf.Clamp(newPosition.x, roomMinX, roomMaxX);
                newPosition.y = Mathf.Clamp(newPosition.y, roomMinY, roomMaxY);


                //checks if plant has reached position
                if ((Vector2)transform.position == targetPosition)
                {
                    isMoving = false;
                }
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

    public Canvas[] windows;

    public void ToggleWindow(int windowIndex)
    {
        // Ensure the windowIndex is valid.
        if (windowIndex >= 0 && windowIndex < windows.Length)
        {
            // Toggle the state of the Canvas element at the specified index.
            windows[windowIndex].gameObject.SetActive(!windows[windowIndex].gameObject.activeSelf);

            // Add logic for reducing water drain rate if the window is open.
            if (windows[windowIndex].gameObject.activeSelf)
            {
                waterLevel -= (waterDrainRate - 2) * Time.deltaTime;
            }

            
        }

    }

}
