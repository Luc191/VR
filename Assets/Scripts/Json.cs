using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Json : MonoBehaviour
{
    public Text _text1;
    public Text _text2;
    public string jsonURL;
    public JsonClass jsonData ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetData()
    {
        var request = new UnityWebRequest(jsonURL);
        request.method = UnityWebRequest.kHttpVerbGET;
        var result = Path.Combine(Application.persistentDataPath, "Result.json");
        var handler = new DownloadHandlerFile(result);
        handler.removeFileOnAbort = true;
        request.downloadHandler = handler;
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            _text1.text = "[Didn't get data]";
            _text2.text = _text1.text;
        }
        else
        {
            jsonData = JsonUtility.FromJson<JsonClass>(File.ReadAllText(Application.persistentDataPath + "/Result.json"));
            _text1.text = jsonData.ObjectName.ToString();
            _text2.text = jsonData.Info.ToString();
            yield return StartCoroutine(GetData());
        }
    }

    [System.Serializable]
    public class JsonClass
    {
        public string ObjectName;
        public string Info;
    }
}
