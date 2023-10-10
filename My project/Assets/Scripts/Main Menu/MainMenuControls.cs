using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Play()
    {

        SceneManager.LoadScene("Study");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
