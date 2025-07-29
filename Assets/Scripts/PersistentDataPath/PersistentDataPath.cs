using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string _fileName = "playerdata.txt";

    void Start()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, _fileName);

        SaveData(fullPath, "Гра збережена");

        string loadedData = LoadData(fullPath);
        Debug.Log("Завантажено: " + loadedData);
    }

    void SaveData(string path, string content)
    {
        File.WriteAllText(path, content);
        Debug.Log("Дані збережено за шляхом: " + path);
    }

    string LoadData(string path)
    {
        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        else
        {
            Debug.LogWarning("Файл не знайдено!");
            return "";
        }
    }
}
