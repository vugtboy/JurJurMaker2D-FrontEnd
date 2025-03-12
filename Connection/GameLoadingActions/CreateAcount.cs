using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;
public class CreateAcount : MonoBehaviour
{
    //voor een button om een acount aan te maken
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
    //waneer je een acount aanmaakt
    public async void Click()
    {
        bool containsNonAlphanumeric = false;
        //de gegevens instellen op de ingevoerde gegevens
        string email = this.email.text;
        string password = this.password.text;
        //het wachtwoord moet een alfaneumeric bevatten hier checken we dat
        foreach (char c in password)
        {
            if (!char.IsLetterOrDigit(c))
            {
                containsNonAlphanumeric = true;
                break;
            }
        }
        // als er ook een uppercase lowercase en cijfer inzitten en de lengte minstens 10 is is het wachtwoord geldig
        if (password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Any(char.IsLower) && containsNonAlphanumeric && password.Length >= 10) 
        {
            //de email is een geldige email, als er één @ in zit, en er voor en na de @ text is, verder mogen er geen niet alfanumerics inzitten behalve de punt
            if (email.Contains("@") && email.IndexOf('@') > 0 && email.IndexOf('@') < email.Length - 1 && IsValidEmail(email))
            {
                //de LoginRepository een call laten doen met de email een paswrood om te registreren
                string result = await client.Register(email, password);
                //als het resultaat succes was is het aangemaakt en moet je inloggene
                if (result != null && result == "succes")
                {
                    Login.transform.Find("Email").GetComponent<TMP_InputField>().text = this.email.text;
                    Register.SetActive(false);
                    Login.SetActive(true);
                }
                //als het geen goed resultaat was is het acount al bezet
                else if (result != "succes" && result != null)
                {
                    Taken.SetActive(true);
                }
            }
            //foutmelding email niet goed
            else
            {
                BadEmail.SetActive(true);
            }
        }
        //foutmelding wachtwoord niet goed
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
    //checken of er 1 @ in zit, er voor en na geen niet alfaneumerics zijn, behalve de punt en de @ zelf
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
