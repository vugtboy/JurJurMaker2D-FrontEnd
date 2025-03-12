using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

//repository om mee in te loggen
public class LoginRepository : MonoBehaviour
{
    private string testingstringacount = "https://avansict2226884.azurewebsites.net/account";

    private ApiClient client;
    void Awake()
    {
        client = GetComponent<ApiClient>();
    }

    //registeren met nieuw wachtwoord en email
    public async Task<string> Register(string email, string password)
    {
        PostRegisterRequestDto request = new PostRegisterRequestDto();
        request.email = email;
        request.password = password;
        var response = await client.PerformApiCall(testingstringacount + "/register", "Post", JsonUtility.ToJson(request));
        
        if (response != null)
        {
            return "succes";
        }
        else
        {
            return "failed";
        }
    }
    //inlogen met wachtwoord en email
    public async Task<string> Login(string email, string password)
    {
        PostLoginRequestDto request = new PostLoginRequestDto();
        request.email = email;
        request.password = password;
        var response = await client.PerformApiCall(testingstringacount + "/login", "Post", JsonUtility.ToJson(request));
        if (response != null)
        {
            client.responseDto = JsonUtility.FromJson<PostLoginResponseDto>(response);
            StartCoroutine(TokenExpire(client.responseDto.expiresIn));
            return "succes";
        }
        else
        {
            return "failed";
        }
    }

    //tokenrefreshen
    public async void Refresh(string refreshToken)
    {
        var response = await client.PerformApiCall(testingstringacount + "/refresh", "Post", JsonUtility.ToJson(client.responseDto));
        client.responseDto = JsonUtility.FromJson<PostLoginResponseDto>(response);
        StartCoroutine(TokenExpire(client.responseDto.expiresIn));
    }

    //na bepaalde refreshtijd refreshen
    IEnumerator TokenExpire(int expiresIn)
    {
        yield return new WaitForSeconds(expiresIn - 120f);
        Refresh(client.responseDto.refreshToken);
    }
}
