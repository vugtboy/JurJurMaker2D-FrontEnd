using UnityEngine;
using TMPro;
public class CreateAcount : MonoBehaviour
{
    private LoginRepository client;

    public TMP_InputField email;
    public TMP_InputField password;

    private GameObject Login;
    private GameObject Register;

    void Start()
    {
        Login = GameObject.Find("#Login");
        Register = GameObject.Find("#Create Acount");
        client = GameObject.Find("APIManager").GetComponent<LoginRepository>();
    }

    public async void Click()
    {
        string email = this.email.text;
        string password = this.password.text;
        string result = await client.Register(email, password);
        if (result != null && result == "succes")
        {
            Login.transform.Find("Email").GetComponent<TMP_InputField>().text = this.email.text;
            Register.SetActive(false);
            Login.SetActive(true);
        }
    }

    void OnDisable()
    {
        this.email.text = string.Empty;
        this.password.text = string.Empty;
    }
}
