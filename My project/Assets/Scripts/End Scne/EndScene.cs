using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{





    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }


    public void Exit()
    {
        Application.Quit();
    }
}
