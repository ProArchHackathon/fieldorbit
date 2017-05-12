using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ServiceController : MonoBehaviour
{

    private string URl = "http://192.168.21.161/dev-fieldorbit-api/api/Job/GetVRJob";

   
    void Start()
    {
        var results = GET(1);
    }
    public WWW GET(int jobid)
    {
        WWW www = new WWW(URl + "?jobId=" + jobid);
        StartCoroutine(WaitForRequest(www));
        return www;
    }
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            print(www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

}
