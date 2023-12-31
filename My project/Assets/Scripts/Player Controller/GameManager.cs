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

    private void Start()
    {
        lastTimeScoored = Time.time;
    }

    private void Update()
    {
        if(Time.time - lastTimeScoored >= timePerScore)
        {
            UpdateScore(1);
            lastTimeScoored = Time.time;
        }


        if(score >= LivingRoomUnlock)
        {
            maxX = 2793F;
            cameraController.minXMax = new Vector2(221, 2617);

        }

        if(score >= studyRoomUnlock)
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
}
