using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class MapSizeEditReader : MonoBehaviour
{
    public Scrollbar heigthEditor;
    public Scrollbar lengthEditor;

    public int heigth;
    public int length;

    public TMP_Text heigthText;
    public TMP_Text lengthText;
    public MapSize mapSize;

    public GameObject warning;

    public GameObject menu;
    public GameObject button;
    void Start()
    {
        
    }

    void OnEnable()
    {
        mapSize = GameObject.Find("MapSizeEditor").GetComponent<MapSize>();
        float _heigth = mapSize.maxHeigth;
        float _length = mapSize.maxLength;
        heigthEditor.value = ((_heigth) - 13) / 86;
        lengthEditor.value = ((_length) - 24) / 175;
    }

    void Update()
    {
        heigth = Convert.ToInt32(13 + (86 * heigthEditor.value));
        length = Convert.ToInt32(24 + (175 * lengthEditor.value));
        heigthText.text = (heigth + 1).ToString();
        lengthText.text = (length + 1).ToString();
    }

    public void WarningMessage()
    {
        if (heigth < mapSize.maxHeigth || length < mapSize.maxLength)
        {
            warning.SetActive(true);
        }
        else
        {
            TurnOfEditMenu();
            UpdateMapSize();
        }
    }

    public void UpdateMapSize()
    {
        mapSize.UpdateWorldSize(heigth, length);
    }

    public void TurnOfEditMenu()
    {
        menu.SetActive(false);
        button.SetActive(true);
    }
}
