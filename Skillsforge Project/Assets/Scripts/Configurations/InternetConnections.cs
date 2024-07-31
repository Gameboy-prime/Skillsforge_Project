using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class InternetConnections : MonoBehaviour
{
   
    IEnumerator Checking()
    {
        UnityWebRequest request = new UnityWebRequest("https://www.google.com");
        yield return request.SendWebRequest();

        if(request.error != null)
        {
            Debug.Log("Game Can continue");
        }

        else
        {
            Debug.Log("Game Can't continue");
        }
        
    }

    private void Start()
    {
        CheckForInternet();
    }

    public void CheckForInternet()
    {
        StartCoroutine(Checking());
    }
}
