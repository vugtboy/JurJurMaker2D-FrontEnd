using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
public class ObjectRepository : MonoBehaviour
{
    //repository voor alles met objecten
    private ApiClient client;
    private string testingUrl = "https://avansict2226884.azurewebsites.net";
    void Start()
    {
        client = GameObject.Find("APIManager").GetComponent<ApiClient>();
    }
    //een object verwijderen, waar het objectId gelijk is aan het ingevoerde objectId
    public async void DeleteObject(string objectId)
    {
        var response = await client.PerformApiCall(testingUrl + "/Object2D?id=" + objectId, "Delete", null, client.responseDto.accessToken);
    }
    //alle objects van een wereld op id van de wereld ophalen
    public async Task<List<GetAllObjectsResponseDto>> GetAllObjects(string id)
    {
        var response = await client.PerformApiCall(testingUrl + "/Object2D/GetAllObject2D?id=" + id, "Get", null, client.responseDto.accessToken);
        if (response != null && !string.IsNullOrEmpty(response))
        {
            List<GetAllObjectsResponseDto> result = JsonHelper.ParseJsonArray<GetAllObjectsResponseDto>(response);
            return result;
        }
        else
        {
            return new List<GetAllObjectsResponseDto>();
        }
    }
    //objecten opslaan/wijzigen in de database, per object
    public async void SaveObject(PostObjectRequestDto request)
    {
        var response = await client.PerformApiCall(testingUrl + "/Object2D", "Put", JsonUtility.ToJson(request), client.responseDto.accessToken);
    }
    //een nieuw object aanmaken
    public async void CreateObject(PostObjectRequestDto request)
    {
        var response = await client.PerformApiCall(testingUrl + "/Object2D", "Post", JsonUtility.ToJson(request), client.responseDto.accessToken);
    }
}
