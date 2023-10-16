using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public GameObject[] roomWindows; // Assign the room windows in the Inspector.

    public void ToggleRoomWindow(int roomIndex)
    {
        if (roomIndex >= 0 && roomIndex < roomWindows.Length)
        {
            roomWindows[roomIndex].SetActive(!roomWindows[roomIndex].activeSelf);
        }
    }

}
