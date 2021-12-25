using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class Registration : MonoBehaviour
{
    [SerializeField]TMP_InputField _loginRegistration;
    [SerializeField]TMP_InputField _passwordRegistration;
    [SerializeField]TMP_InputField _mailRegistartion;
    [SerializeField]TMP_InputField _login;
    [SerializeField]TMP_InputField _password;

    [SerializeField] UnityEvent _registSuccess;
    [SerializeField] UnityEvent _loginSuccess;
    public void ButtonRegistration() 
    {
        StartCoroutine(OperationRegistration());
    }

    public void ButtonLogin()
    {
        StartCoroutine(OperationLogin());
    }
    public IEnumerator OperationRegistration()
    {
        Debug.Log(_loginRegistration.text);
        Debug.Log(_passwordRegistration.text);
        Debug.Log(_mailRegistartion.text);
        var client = new WWWForm();
        client.AddField("client_id", "loyam_test");
        client.AddField("client_secret", "0IcbmorPNeuEcywxvaGQzznSd3pIl8BF12hT8eeExuZ2G9XYJH7YHeQh");
        client.AddField("username", _loginRegistration.text);
        client.AddField("password", _passwordRegistration.text);
        client.AddField("email", _mailRegistartion.text);


        UnityWebRequest www = UnityWebRequest.Post("https://test.loy.am/api/users", client);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();

        
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.text);
            _registSuccess?.Invoke();
        }
        
    }
   

    public IEnumerator OperationLogin() 
    {
        var client = new WWWForm();
        client.AddField("grant_type", "password");
        client.AddField("client_id", "loyam_test");
        client.AddField("client_secret", "0IcbmorPNeuEcywxvaGQzznSd3pIl8BF12hT8eeExuZ2G9XYJH7YHeQh");
        client.AddField("username", _login.text);
        client.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post("https://test.loy.am/api/users", client);
        www.SetRequestHeader("Accept", "application/json");
        string token="";
        //www.SetRequestHeader("grant_type", "password");
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.text);
            _loginSuccess?.Invoke();
        }
      
    }

}
