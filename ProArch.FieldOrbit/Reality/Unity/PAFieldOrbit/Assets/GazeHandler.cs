using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GazeHandler : Singleton<GazeHandler>
{
    private Color startColor;

    public TextMesh txtData;
    public TextMesh C1JDes;
    public TextMesh C1JPry;

    public TextMesh C2JId;
    public TextMesh C2JDes;
    public TextMesh C2JPry;

    public TextMesh C3JId;
    public TextMesh C3JDes;
    public TextMesh C3Pry;

    List<TextMesh> m_Controls = new List<TextMesh>();
    List<JobModel> l_Jobs = new List<JobModel>();
    private string URl = "http://192.168.21.161/test-fieldorbit-api/api/Job/GetVRJob";
    // Use this for initialization
    void Start()
    {
        JobModel l_Data1 = new JobModel() { JobId = 1, JobDescription = "Device Repair", Priority = "high" };
        JobModel l_Data2 = new JobModel() { JobId = 2, JobDescription = "Device Installation", Priority = "high" };
        JobModel l_Data3 = new JobModel() { JobId = 3, JobDescription = "Reparing the Transnformer", Priority = "high" };
        l_Jobs.Add(l_Data1); l_Jobs.Add(l_Data2); l_Jobs.Add(l_Data3);
        txtData.tag = "1";
        C1JDes.tag = "1";
        C1JPry.tag = "1";

        C2JId.tag = "2";
        C2JDes.tag = "2";
        C2JPry.tag = "2";

        C3JId.tag = "3";
        C3JDes.tag = "3";
        C3Pry.tag = "3";
        m_Controls.Add(txtData); m_Controls.Add(C1JDes); m_Controls.Add(C1JPry);
        m_Controls.Add(C2JId); m_Controls.Add(C2JDes); m_Controls.Add(C2JPry);
        m_Controls.Add(C3JId); m_Controls.Add(C3JDes); m_Controls.Add(C3Pry);


        txtData.text = string.Empty;
        C1JDes.text = string.Empty;
        C1JPry.text = string.Empty;

        C2JId.text = string.Empty;
        C2JDes.text = string.Empty;
        C2JPry.text = string.Empty;

        C3JId.text = string.Empty;
        C3JDes.text = string.Empty;
        C3Pry.text = string.Empty;
        //for (int i = 1; i <= 3; i++)
        //{
        //    var results = GET(i);

        //    int count = 1;
        //    while (count < 10000000)
        //    {
        //        count++;
        //    }

        //    JobModel l_Job = GetObject(results.text);
        //    l_Jobs.Add(l_Job);
        //}
    }

    // Update is called once per frame
    void Update()
    {
    }

    void BuildData(JobModel l_JobDetails)
    {
        txtData.text = string.Empty;
        C1JDes.text = string.Empty;
        C1JPry.text = string.Empty;

        C2JId.text = string.Empty;
        C2JDes.text = string.Empty;
        C2JPry.text = string.Empty;

        C3JId.text = string.Empty;
        C3JDes.text = string.Empty;
        C3Pry.text = string.Empty;
        //foreach (TextMesh l_Ctrl in m_Controls)
        //{

        if (l_JobDetails.JobId.ToString() == "1")
        {
            txtData.text = "Job Id:" + l_JobDetails.JobId.ToString();
            C1JDes.text = "Description:" + l_JobDetails.JobDescription;
            C1JPry.text = "Priority:" + l_JobDetails.Priority;
        }
        else if (l_JobDetails.JobId.ToString() == "2")
        {
            C2JId.text = "Job Id:" + l_JobDetails.JobId.ToString();
            C2JDes.text = "Description:" + l_JobDetails.JobDescription;
            C2JPry.text = "Priority:" + l_JobDetails.Priority;
        }
        else
        {
            C3JId.text = "Job Id:" + l_JobDetails.JobId.ToString();
            C3JDes.text = "Description:" + l_JobDetails.JobDescription;
            C3Pry.text = "Priority:" + l_JobDetails.Priority;
        }
        //}
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
    //For testing
    void OnMouseDown()
    {
        var com = gameObject.GetComponent<Renderer>();
        string l_Tag = com.tag;
        if (l_Tag == "4")
        {
            Launcher.LaunchUri("skype:proarch-hyd?call", false);
        }
        else
        {
            int l_JobId = 1;
            int.TryParse(l_Tag, out l_JobId);
            JobModel l_Job = l_Jobs.Find(a => a.JobId == l_JobId);
            BuildData(l_Job);
        }
    }




    JobModel GetObject(string input)
    {
        try
        {
            JobModel l_Model = new JobModel();

            string[] l_Data = input.Split(new char[] { ',' });
            foreach (string l_str in l_Data)
            {
                string[] l_Data1 = l_str.Split(new char[] { ':' });
                if (l_Data1[0].Contains("JobId"))
                {
                    string model = l_Data1[1].ToString().Replace("\\", " ").Trim();

                    l_Model.JobId = Convert.ToInt32(model);
                }
                else if (l_Data1[0].Contains("Priority"))
                {
                    l_Model.Priority = l_Data1[1].ToString().Trim().Substring(1, l_Data1[1].ToString().Length - 3);
                }
                else
                {
                    l_Model.JobDescription = l_Data1[1].ToString().Trim().Substring(1, l_Data1[1].ToString().Length - 2);
                }
            }
            return l_Model;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void OnGazeEnter()
    {
        var com = gameObject.GetComponent<Renderer>();
        //startColor = com.material.color;
        //com.material.color = Color.yellow;
        string l_Tag = com.tag;
        //if (l_Tag == "4")
        //{
        //    Launcher.LaunchUri("skype:proarch-hyd?call", false);
        //}
        int l_JobId = 1;
        int.TryParse(l_Tag, out l_JobId);
        //txtData.text = l_Tag + ":" + l_JobId;
        //C1JDes.text = "Count:" + l_Jobs.Count.ToString();
        JobModel l_Job = l_Jobs.Find(a => a.JobId == l_JobId);
        // + "::" + l_Job.JobDescription;
        BuildData(l_Job);


    }

    void OnGazeExit()
    {
        var com = gameObject.GetComponent<Renderer>();
        //com.material.color = startColor;
        //txtData.text = string.Empty;
    }
}
