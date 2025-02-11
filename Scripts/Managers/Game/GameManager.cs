using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int numberCoinDestroyed = 0;
    public bool createCoins = true;
    [SerializeField] private GameObject coinPrefab;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Level management
    public void UnlockNextLevel(int level)
    {
        PlayerPrefs.SetInt("Level" + level, 1);
        PlayerPrefs.Save();
    }

    public bool IsLevelUnlocked(int level)
    {
        return PlayerPrefs.GetInt("Level" + level, 0) == 1;
    }

    // Save and load game progress
    public void SaveGame(int coins, int level)
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("CurrentLevel", level);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        numberCoinDestroyed = PlayerPrefs.GetInt("Coins", 0);
    }
}
