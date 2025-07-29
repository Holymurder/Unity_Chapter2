using UnityEngine;
using System.IO;

public class JsonWriter : MonoBehaviour
{
    void Start()
    {
        PlayerData player = new PlayerData
        {
            Name = "Andry",
            Level = 5,
            Health = 88.5f
        };

        string json = JsonUtility.ToJson(player, true);
        string path = Path.Combine(Application.streamingAssetsPath, "player.json");
        File.WriteAllText(path, json);

        Debug.Log("Saved to: " + path);
    }
}
