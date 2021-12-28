using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginRegistration;
    [SerializeField] private TMP_InputField passwordRegistration;
    [SerializeField] private TMP_InputField mailRegistartion;
    [SerializeField] private TMP_InputField loginAutorization;
    [SerializeField] private TMP_InputField passwordAutorization;

    [SerializeField] public UnityEvent RegistSuccess;
    [SerializeField] public UnityEvent RegistError;
    [SerializeField] public UnityEvent LoginSuccess;
    [SerializeField] public UnityEvent LoginError;
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
        Debug.Log(loginRegistration.text);
        Debug.Log(passwordRegistration.text);
        Debug.Log(mailRegistartion.text);
        var client = new WWWForm();
        client.AddField("client_id", "loyam_test");
        client.AddField("client_secret", "0IcbmorPNeuEcywxvaGQzznSd3pIl8BF12hT8eeExuZ2G9XYJH7YHeQh");
        client.AddField("username", loginRegistration.text);
        client.AddField("password", passwordRegistration.text);
        client.AddField("email", mailRegistartion.text);


        UnityWebRequest www = UnityWebRequest.Post("https://test.loy.am/api/users", client);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();

        
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
            RegistError?.Invoke();
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.text);
            RegistSuccess?.Invoke();
        }
        
    }
   

    public IEnumerator OperationLogin() 
    {
        var client = new WWWForm();
        client.AddField("grant_type", "password");
        client.AddField("client_id", "loyam_test");
        client.AddField("client_secret", "0IcbmorPNeuEcywxvaGQzznSd3pIl8BF12hT8eeExuZ2G9XYJH7YHeQh");
        client.AddField("username", loginAutorization.text);
        client.AddField("password", passwordAutorization.text);

        UnityWebRequest www = UnityWebRequest.Post("https://test.loy.am/oauth/token", client);
        www.SetRequestHeader("Accept", "application/json");
        string token="";
        //www.SetRequestHeader("grant_type", "password");
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            LoginError?.Invoke();
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.text);
            LoginSuccess?.Invoke();
        }
      
    }

}
