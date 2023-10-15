using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject bookPanel;

    public GameObject wateringCan;

    public GameObject Book;

    public GameObject score;

    public GameObject EndScreen;

    public Plant plant;

    public GameObject endScreen;






    private void Start()
    {
        bookPanel.SetActive(false);
        
    }


    public void OpenBook()
    {
        bookPanel.SetActive(true);
        Time.timeScale = 0f;
        Book.SetActive(false);
        wateringCan.SetActive(false);
        score.SetActive(false);
    }


    public void EnableWatering()
    {
        Debug.Log("Watering can clicked");
    }

    public void Close()
    {
        Time.timeScale = 1f;
        bookPanel.SetActive(false);
        Book.SetActive(true);
        wateringCan.SetActive(true);
        score.SetActive(true);
    }

}
