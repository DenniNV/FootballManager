using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.Text;

public class RequestOnServer 
{
    private readonly string _ipAdress = "104.248.255.145";
    public string SendDataToServer()
    {
        WebClient client = new WebClient();

        // This specialized key-value pair will store the form data we're sending to the server
        var loginData = new System.Collections.Specialized.NameValueCollection();
        loginData.Add("package", "0");
        // Upload client data and receive a response [// Загрузить данные клиента и получить ответ] 
        byte[] opBytes = client.UploadValues(_ipAdress, "POST", loginData);
        // Encode the response bytes into a proper string
        string opResponse = Encoding.UTF8.GetString(opBytes);
        Debug.Log(opResponse);
        return opResponse;
    }

    readonly string url = "http://104.248.255.145/api/check-clean";
    readonly string _packageName = "com.footballmanager.footballpenalty";
    public IEnumerator Connection()
    {
        WWWForm form = new WWWForm();
        form.AddField("package", _packageName);
        UnityWebRequest Add = UnityWebRequest.Post(url, form);
        yield return Add.SendWebRequest();
        string opResponse = Encoding.UTF8.GetString(Add.downloadHandler.data);
        Debug.Log(opResponse);

    }

}


