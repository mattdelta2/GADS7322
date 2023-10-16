using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float score = 0f;

    public TextMeshProUGUI scoreText;

    public float timePerScore = 1f;

    public float mixX = 282f;
    public float maxX = 520f;

    public CameraController cameraController;

    private float LivingRoomUnlock = 100f;

    private float studyRoomUnlock = 150f;

    private float lastTimeScoored;

    public GameObject[] intialRoomPlants;
    public GameObject[] nextRoomPlants;
    public GameObject[] finalRoomPlants;

    private bool nextRoomUnlocked = false;
    private bool lastRoomUnlocked = false;

    public Vector2 minSpawnPosition;
    public Vector2 maxSpawnPosition;

    public float finalScore;




    private void Start()
    {
        Time.timeScale = 1f;
        lastTimeScoored = Time.time;
        SpawnInitialRoomPlants();
    }

    private void Update()
    {
        if(Time.time - lastTimeScoored >= timePerScore)
        {
            UpdateScore(1);
            lastTimeScoored = Time.time;
        }


        if(score >= LivingRoomUnlock && !nextRoomUnlocked)
        {
            maxX = 2793F;
            cameraController.minXMax = new Vector2(221, 2617);
            UnlockNextRoom();


        }

        if(score >= studyRoomUnlock && !lastRoomUnlocked)
        {
            maxX = 4732;
            cameraController.minXMax = new Vector2(221, 4630);
            FinalRoom();
        }
    }

    private void UpdateScore(float points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }



    void SpawnInitialRoomPlants()
    {

        Vector2[] plantPositions = new Vector2[]
        {
            new Vector2(294f, 640f),
            new Vector2(549f, 643f),
            new Vector2(798f, 617f)
        };

        if(plantPositions.Length != intialRoomPlants.Length)
        {
            Debug.LogError("Number of plant positions must match the number of plant prefabs.");
            return;
        }

        for (int i = 0; i < intialRoomPlants.Length; i++)
        {
            // Instantiate the plant.
            GameObject newPlant = Instantiate(intialRoomPlants[i]);

            // Set the specific position for the plant.
            newPlant.transform.position = plantPositions[i];
        }

    }

    void UnlockNextRoom()
    {
        Vector2[] nextRoomPlantPosistions = new Vector2[]
        {
            new Vector2(2843,711),
            new Vector2(2843,557),
            new Vector2(2010,159)

        };

        if(nextRoomPlantPosistions.Length != nextRoomPlants.Length)
        {
            Debug.LogError("Number of plant positions must match the number of plant prefabs.");
            return;

        }

        for(int i = 0;i < nextRoomPlantPosistions.Length;i++)
        {
            GameObject nextRoomPlant = Instantiate(nextRoomPlants[i]);

            nextRoomPlant.transform.position = nextRoomPlantPosistions[i];
        }
        nextRoomUnlocked = true;

    }

    void FinalRoom()
    {
        Vector2[] LastRoomPlantPosistions = new Vector2[]
       {
            new Vector2(3863,159),
            new Vector2(4207,159),
            new Vector2(4609,191),
            new Vector2(3778, 441)

       };

        if (LastRoomPlantPosistions.Length != finalRoomPlants.Length)
        {
            Debug.LogError("Number of plant positions must match the number of plant prefabs.");
            return;

        }

        for (int i = 0; i < LastRoomPlantPosistions.Length; i++)
        {
            GameObject nextRoomPlant = Instantiate(finalRoomPlants[i]);

            nextRoomPlant.transform.position = LastRoomPlantPosistions[i];
        }
        


        lastRoomUnlocked = true;
    }


     public void endGame()
    {

        finalScore = score;

        PlayerPrefs.SetFloat("FinalScore", finalScore);
        PlayerPrefs.Save();

    }

}
