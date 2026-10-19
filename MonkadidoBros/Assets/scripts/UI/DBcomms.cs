using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DBcomms : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText() 
    {
        UnityWebRequest www = UnityWebRequest.Get("");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else 
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
    IEnumerator SendPlayerScore() 
    {
        using (UnityWebRequest www = UnityWebRequest.Post("", "{ \"field1\": 1, \"field2\": 2 }", "application/json")) 
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else 
            {
                Debug.Log("Form upload complete");
            }
        }
    }
}
