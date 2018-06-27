using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using System;
public class GetJsonDataScript : MonoBehaviour
{
    // Use this for initialization
    string Url;
    Person newPerson;
    void Start()
    {
        Url = "http://http://localhost:8000/api/cervejas/1";
        newPerson = new Person();
        GetData();
    }
    // Update is called once per frame
    void Update()
    {

    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Invoke this function where to want to make request.
    void GetData()
    {
        //sending the request to url
        WWW www = new WWW(Url);
        StartCoroutine("GetdataEnumerator", Url);
    }

    IEnumerator GetdataEnumerator(WWW www)
    {
        //Wait for request to complete
        yield return www;
        if (www.error != null)
        {
            string serviceData = www.text;
            //Data is in json format, we need to parse the Json.
            Debug.Log(serviceData);
            JSONObject json = JSONObject.Parse(serviceData);
            if (json == null)
            {
                Debug.Log("No data converted");
            }
            else
            {
                //now we can get the values from json of any attribute.
                newPerson.Id = Convert.ToInt32(json["Id"].Number);
                newPerson.Name = json["Name"].Str;
            }
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}