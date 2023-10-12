using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject bookPanel;

    public GameObject wateringCan;

    



    private void Start()
    {
        bookPanel.SetActive(false);
        
    }


    public void OpenBook()
    {
        bookPanel.SetActive(true);
        Time.timeScale = 0f;
    }


    public void EnableWatering()
    {
        Debug.Log("Watering can clicked");
    }

    public void Close()
    {
        Time.timeScale = 1f;
        bookPanel.SetActive(false);
    }


}
