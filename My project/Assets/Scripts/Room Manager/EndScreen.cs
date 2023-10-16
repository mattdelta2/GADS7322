using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI FinalScore;

        private void Start()
    {
        float finalScore = PlayerPrefs.GetFloat("FinalScore", 0);

        FinalScore.text += finalScore;

    }








}
