using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    private LoginRepository client;

    public TMP_InputField email;
    public TMP_InputField password;

    private PostLoginResponseDto responseDto;
    public GameObject failedToLogin;
    void Start()
    {
        client = GameObject.Find("APIManager").GetComponent<LoginRepository>();
    }

    public async void Click()
    {
        string email = this.email.text;
        string password = this.password.text;
        string result = await client.Login(email, password);
        if(result == "succes")
        {
            SceneManager.LoadScene("Worldview");
        }
        else
        {
            failedToLogin.SetActive(true);
        }
    }

    void OnDisable()
    {
        this.email.text = string.Empty;
        this.password.text = string.Empty;
    }
}
