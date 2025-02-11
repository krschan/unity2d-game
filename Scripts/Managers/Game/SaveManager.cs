using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int coins;
    public int currentLevel;
}

public class SaveManager : MonoBehaviour
{
    public static void SaveGameToFile(string saveName)
    {
        SaveData data = new SaveData();
        data.coins = GameManager.Instance.numberCoinDestroyed;
        data.currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + saveName + ".json", json);
    }

    public static void LoadGameFromFile(string saveName)
    {
        string path = Application.persistentDataPath + "/" + saveName + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            GameManager.Instance.numberCoinDestroyed = data.coins;
            PlayerPrefs.SetInt("CurrentLevel", data.currentLevel);
        }
    }
}
