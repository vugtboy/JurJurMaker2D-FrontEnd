using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;
public class WorldRepository : MonoBehaviour
{
    private string testingUrl = "https://avansict2226884.azurewebsites.net";
    private ApiClient client;
    
    void Awake()
    {
        client = GetComponent<ApiClient>();
    }

    //userId ophalen
    public async Task<string> GetUserId()
    {
        var response = await client.PerformApiCall(testingUrl + "/Environment2D/GetUserId", "Get", null, client.responseDto.accessToken);
        if (response != null)
        {
            return response;
        }
        return string.Empty;
    }

    //alle worlds inladen
    public async Task<List<GetWorldResponseDto>> GetAllWorlds(string userId)
    {
        var response = await client.PerformApiCall(testingUrl + "/Environment2D/GetAllEnvironment2D?Userid=" + userId, "Get", null, client.responseDto.accessToken);
        if (response != null && !string.IsNullOrEmpty(response))
        {
            List<GetWorldResponseDto> result = JsonHelper.ParseJsonArray<GetWorldResponseDto>(response);
            return result;
        }
        else
        {
            return new List<GetWorldResponseDto>();
        }
    }

    public async void CreateNewWorld(string Name, int Heigth, int Length, string userId, Guid id)
    {
        CreateWorldRequestDto request = new CreateWorldRequestDto();
        request.name = Name;
        request.maxLength = Length;
        request.maxHeigth = Heigth;
        request.userId = userId;
        request.id = id.ToString();
        request.player = 0;
        request.music = 0;
        request.background = 0;
        var response = await client.PerformApiCall(testingUrl + "/Environment2D", "Post", JsonUtility.ToJson(request), client.responseDto.accessToken);
    }

    public async void DeleteWorld(string id)
    {
        await client.PerformApiCall(testingUrl + "/Environment2D?id=" + id, "Delete", null, client.responseDto.accessToken);
    }

    public async void SaveWorld(PutWorldRequestDto request)
    {
        var response = await client.PerformApiCall(testingUrl + "/Environment2D", "Put", JsonUtility.ToJson(request), client.responseDto.accessToken);
    }
}
