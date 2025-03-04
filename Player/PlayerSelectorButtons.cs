using UnityEngine;

public class PlayerSelectorButtons : MonoBehaviour
{
    public bool selected;
    public GameObject Buttons;
    public GameModeManager modeManager;
    void Start()
    {
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
}
