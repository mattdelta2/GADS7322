using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    

   
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);

            }

        }
      
        
    }

    public void MainMenu()

    {
        SceneManager.LoadScene("MainMenu");
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {

        Application.Quit();
        
    }
}
