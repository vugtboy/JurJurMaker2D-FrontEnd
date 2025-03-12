using UnityEngine;
using System.Collections;
public class PlayerSelectorButtons : MonoBehaviour
{
    //als je op rechtermuisknop drukt op de speler moeten de selectieknoppen verschijnen om te kunnen kiezen uit spelers
    public bool selected;
    public GameObject Buttons;
    public GameModeManager modeManager;
    private GameObject placer;
    void Start()
    {
        placer = GameObject.Find("#Placer#");
        Buttons = GameObject.Find("#PlayerSetButtons");
        modeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(selected)
            {
                Buttons.SetActive(false);
                selected = false;
            }
            else
            {
                Buttons.SetActive(true);
                selected = true;
            }
        }
    }   

    public void TurnOff()
    {
        selected = false;
        StartCoroutine(fixPlacer());
    }

    IEnumerator fixPlacer()
    {
        yield return new WaitForSeconds(0.1f);
        placer.SetActive(true);
    }

}
