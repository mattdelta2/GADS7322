using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnlock : MonoBehaviour
{
    public int[] scoreThresholds; // Score thresholds for unlocking rooms.
    public GameObject[] rooms; // References to room GameObjects.
    private int currentRoomIndex = 0; // Index of the current unlocked room.

    // Reference to the player's score.
    public int playerScore = 0;

    void Start()
    {
        // Ensure the initial room is unlocked.
        UnlockRoom(0);
    }

    void Update()
    {
        // Check for score changes and unlock new rooms if thresholds are met.
        CheckForRoomUnlock();
    }

    // Check if the player's score reaches a threshold to unlock a new room.
    void CheckForRoomUnlock()
    {
        if (currentRoomIndex < scoreThresholds.Length)
        {
            if (playerScore >= scoreThresholds[currentRoomIndex])
            {
                UnlockRoom(currentRoomIndex + 1);
            }
        }
    }

    // Unlock a new room and disable the previous one.
    void UnlockRoom(int roomIndex)
    {
        if (roomIndex < rooms.Length)
        {
            

            // Enable the new room.
            rooms[roomIndex].SetActive(true);
            currentRoomIndex = roomIndex;
        }
    }
}
