using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;
    public async void Register()
    {
        PostRegisterRequestDto request = new PostRegisterRequestDto();
        request.email = "JurJurVugter@hotmail.co";
        request.password = "33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!33nW @chtWoord!";
        await PerformApiCall("https://avansict123456.azurewebsites.net/account/register", "Post", JsonUtility.ToJson(request));
    }

    public async void Login()
    {
        PostLoginRequestDto request = new PostLoginRequestDto();
        request.email = email.text;
        request.password = password.text;
        var response = await PerformApiCall("https://avansict123456.azurewebsites.net/account/login", "Post", JsonUtility.ToJson(request));
        Debug.Log(response);
        PostLoginResponseDto responseDto = JsonUtility.FromJson<PostLoginResponseDto>(response);
    }

    private async Task<string> PerformApiCall(string url, string method, string jsonData = null, string token = null)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, method))
        {
            if (!string.IsNullOrEmpty(jsonData))
            {
                byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(token))
            {
                request.SetRequestHeader("Authorization", "Bearer " + token);
            }

            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                return request.downloadHandler.text;
            }
            else
            {
                return null;
            }
        }
    }
}
