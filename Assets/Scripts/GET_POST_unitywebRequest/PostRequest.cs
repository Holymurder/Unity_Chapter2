using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class PostRequest : MonoBehaviour
{
    private string _url = "https://jsonplaceholder.typicode.com/posts";

    void Start()
    {
        StartCoroutine(SendPostRequest());
    }

    IEnumerator SendPostRequest()
    {
        Post newPost = new Post
        {
            UserId = 1,
            Title = "Test Title",
            Body = "Test Body"
        };

        string jsonData = JsonUtility.ToJson(newPost);
        byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);

        UnityWebRequest request = new UnityWebRequest(_url, "POST");
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    [System.Serializable]
    public class Post
    {
        public int UserId; 
        public string Title;
        public string Body;
    }
}
