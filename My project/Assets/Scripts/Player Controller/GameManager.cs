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

    private float LivingRoomUnlock = 10f;

    private float studyRoomUnlock = 20f;

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

        }

        if(score >= studyRoomUnlock && !lastRoomUnlocked)
        {
            maxX = 4732;
            cameraController.minXMax = new Vector2(221, 4630);
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
        //Instantiate(nextRoomPlants, nextRoomSpawnArea.position, Quaternion.identity);
        nextRoomUnlocked = true;

    }


   /* void endGame()
    {

        finalScore = score;

        PlayerPrefs.SetFloat("FinalScore", finalScore);

    }*/

}
