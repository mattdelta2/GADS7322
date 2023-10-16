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

    public WateringCan WateringCan;

    
    public WindowManager windowManager;

    public int roomIndexToControl;
    private TextMeshProUGUI button;



    public void ToggleRoomWindow()
    {
        Debug.Log("window clicked");
        windowManager.ToggleRoomWindow(roomIndexToControl);
    }





    private void Start()
    {
        
        bookPanel.SetActive(false);
        
    }

    private void Update()
    {
        if (WateringCan.IsWatering)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Plant plant = hit.collider.GetComponent<Plant>();

                    if (plant != null)
                    {
                        AudioSource audioSource = GetComponent<AudioSource>();
                        if (audioSource != null && audioSource.clip != null)
                        {
                            audioSource.Play();
                        }
                        Debug.Log("Plant Clicked!");
                        // Increase the water level of the plant using the watering can's water amount.
                        plant.WaterPlant(WateringCan.WaterAmount);
                        WateringCan.IsWatering = false;
                    }
                }
            }
        }
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
        
        Debug.Log("Can clicked");
        WateringCan.IsWatering = true;
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
