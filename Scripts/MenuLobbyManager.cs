using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLobbyManager : MonoBehaviour
{
    public void clickNewGame()
    {
        SceneManager.LoadScene(1);
    }
}
