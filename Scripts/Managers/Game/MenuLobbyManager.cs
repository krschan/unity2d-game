using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLobbyManager : MonoBehaviour
{
    // This method is called when the "New Game" button is clicked
    public void ClickNewGame()
    {
        SceneManager.LoadScene("Level1"); // Load the first level scene
    }

    // This method is called to load a specific level
    public void LoadLevel(int level)
    {
        // Check if the level is unlocked
        if (GameManager.Instance.IsLevelUnlocked(level))
        {
            SceneManager.LoadScene("Level" + level); // Load the unlocked level scene
        }
        else
        {
            Debug.Log("Level is locked"); // Log a message if the level is locked
        }
    }
}
