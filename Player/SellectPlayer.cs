using UnityEngine;

public class SellectPlayer : MonoBehaviour
{
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
