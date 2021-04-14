using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Net;
using UnityEngine.Networking;


[System.Serializable]
class Data { public string name; public List<string> likes; public int level; }
public class RestApiTest:MonoBehaviour {

    string uri = "https://localhost:44320/jj/";
    DataM dataM;

    // Start is called before the first frame update
    void Start()
    {
        dataM = new DataM();

        dataM.userid = Random.Range(0, 10);
        string userid = "abcdefghijklnmopqrstuvwxyzABCDEFGHIJKLNMOPQRSTUVWXYZ";
        string generatedName = "";
        for (int i = 0; i < 6; i++)
        {
            int select = Random.Range(1, userid.Length);

            generatedName += userid[select];
        }

        dataM.userid = 1 + Random.Range(0, 40000);
        dataM.names = generatedName;
        dataM.phonenumber = "01075357836";

        StartCoroutine(SendRestServer());



    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dataM.userid = 1 + Random.Range(0, 40000);
            dataM.names = "zzz";


            dataM.phonenumber = "01075357836";
            StartCoroutine(SendPostServer());
        }
    }

    private IEnumerator SendRestServer()
    {
        
        string jSon = JsonUtility.ToJson(dataM);
        Debug.Log(dataM.userid);
        Debug.Log("json \n"+jSon);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jSon);
        Debug.Log("byte[] \n " + bytes.Length);

        yield return new WaitForSeconds(1.9f);
        UnityWebRequest restAPI = UnityWebRequest.Put(uri, bytes);

        restAPI.SetRequestHeader("Content-Type", "application/json");

        yield return restAPI.SendWebRequest();
        if (restAPI.error == null)
        {
            // 에러가 안나올떄 동작함
            Debug.Log(" 받은 데이터");
            Debug.Log(restAPI.downloadHandler.text);
        }
        else
        {
            Debug.Log("error");
        }
    }
    private IEnumerator SendPostServer()
    {
        string jSon = JsonUtility.ToJson(dataM);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jSon);

        yield return new WaitForSeconds(1.9f);

        WWWForm form = new WWWForm();

        form.AddField("userid", dataM.userid);
        form.AddField("names", dataM.names);
        form.AddField("phonenumber", dataM.phonenumber);

        UnityWebRequest restAPI = UnityWebRequest.Post(uri, UnityWebRequest.kHttpVerbPOST);
        UploadHandlerRaw raw = new UploadHandlerRaw(bytes);
        raw.contentType = "application/json"; //this is ignored?
        restAPI.uploadHandler = raw;
        


        yield return restAPI.SendWebRequest();
        if (restAPI.error == null)
        {
            // 에러가 안나올떄 동작함
            Debug.Log(" 받은 데이터");
            Debug.Log(restAPI.downloadHandler.text);
        }
        else
        {
            Debug.Log("error");
        }
    }
}
