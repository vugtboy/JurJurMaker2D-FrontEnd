using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//made in depresion
public class CreateWorld : MonoBehaviour
{
    //een klasse die gemaakt is om niewe werelden aan te maken
    public Scrollbar heigthEditor;
    public Scrollbar lengthEditor;

    public int heigth;
    public int length;

    public TMP_Text heigthText;
    public TMP_Text lengthText;

    public TMP_InputField nameInput;
    private string worldName;

    private WorldLoader worldmaker;
    void Start()
    {
        worldmaker = GameObject.Find("WorldLoader").GetComponent<WorldLoader>();
    }

    void OnEnable()
    {
        heigthEditor.value = 1;
        lengthEditor.value = 1;
    }

    //de juiste gegevens ophalen uit de instellingen
    void Update()
    {
        worldName = nameInput.text;
        heigth = Convert.ToInt32(13 + (86 * heigthEditor.value));
        length = Convert.ToInt32(24 + (175 * lengthEditor.value));
        heigthText.text = (heigth + 1).ToString();
        lengthText.text = (length + 1).ToString();
    }
    //als je op de knop drukt een de WorldRepo een call laten doen om een wereld te maken
    public void Create()
    {
        if(worldName.Length >= 1 && worldName.Length <= 25)
        worldmaker.TryToCreateNewWorld(worldName, heigth, length);
    }
}
