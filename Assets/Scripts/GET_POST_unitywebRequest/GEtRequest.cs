using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GetRequest : MonoBehaviour
{
    private string _url = "https://jsonplaceholder.typicode.com/posts/1";

    void Start()
    {
        StartCoroutine(GetDataCoroutine());
    }

    IEnumerator GetDataCoroutine()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(_url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + webRequest.downloadHandler.text);

            PostData postData = JsonUtility.FromJson<PostData>(webRequest.downloadHandler.text);
            Debug.Log("Title: " + postData.Title);
        }
        else
        {
            Debug.LogError("Error: " + webRequest.error);
        }
    }

    [System.Serializable]
    public class PostData
    {
        public int UserId;
        public int Id;
        public string Title;
        public string Body;
    }
}
