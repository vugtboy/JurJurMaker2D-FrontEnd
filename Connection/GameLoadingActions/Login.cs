using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    //inlogen op de knop
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
        // apicall via LoginRepo
        string result = await client.Login(email, password);
        //als het resultaat goed is mag je inloggen
        if(result == "succes")
        {
            SceneManager.LoadScene("Worldview");
        }
        //anders zijn je gegevens fout
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
