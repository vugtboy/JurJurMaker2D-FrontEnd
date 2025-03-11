using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;
public class CreateAcount : MonoBehaviour
{
    private LoginRepository client;

    public TMP_InputField email;
    public TMP_InputField password;

    private GameObject Login;
    private GameObject Register;

    public GameObject Taken;
    public GameObject BadPassword;
    public GameObject BadEmail;
    void Start()
    {
        Login = GameObject.Find("#Login");
        Register = GameObject.Find("#Create Acount");
        client = GameObject.Find("APIManager").GetComponent<LoginRepository>();
    }

    public async void Click()
    {
        bool containsNonAlphanumeric = false;
        string email = this.email.text;
        string password = this.password.text;
        foreach (char c in password)
        {
            if (!char.IsLetterOrDigit(c))
            {
                containsNonAlphanumeric = true;
                break;
            }
        }
        if (password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Any(char.IsLower) && containsNonAlphanumeric && password.Length >= 10) 
        {
            if (email.Contains("@") && email.IndexOf('@') > 0 && email.IndexOf('@') < email.Length - 1 && IsValidEmail(email))
            {
                string result = await client.Register(email, password);
                if (result != null && result == "succes")
                {
                    Login.transform.Find("Email").GetComponent<TMP_InputField>().text = this.email.text;
                    Register.SetActive(false);
                    Login.SetActive(true);
                }
                else if (result != "succes" && result != null)
                {
                    Taken.SetActive(true);
                }
            }
            else
            {
                BadEmail.SetActive(true);
            }
        }
        else
        {
            BadPassword.SetActive(true);
        }
    }

    void OnDisable()
    {
        this.email.text = string.Empty;
        this.password.text = string.Empty;
    }

    bool IsValidEmail(string input)
    {
        
        int atCount = input.Split('@').Length - 1; 
        if (atCount != 1)
        {
            return false;
        }
      
        foreach (char c in input)
        {
            if (c != '@' && c !='.' && !char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}
