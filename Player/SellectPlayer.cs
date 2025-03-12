using UnityEngine;

public class SellectPlayer : MonoBehaviour
{
    //met knop in ui speler selecterem em playerselector dit laten instellen
    public PlayerSelector sellector;
    public int index;
    void Start()
    {
        sellector = GameObject.Find("Player").GetComponent<PlayerSelector>();
    }
    public void Click()
    {
        sellector.SetPlayer(index);
    }
}
