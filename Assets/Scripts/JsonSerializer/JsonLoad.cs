using UnityEngine;
using System.IO;

public class JsonReader : MonoBehaviour
{
    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "player.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData player = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log($"Loaded: Name={player.Name}, Level={player.Level}, Health={player.Health}");
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }
    }
}
