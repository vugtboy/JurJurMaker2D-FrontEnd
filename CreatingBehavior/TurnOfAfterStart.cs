using UnityEngine;

public class TurnOfAfterStart : MonoBehaviour
{
    // somige objecten worden in start opgehaald door scripts om ze later te gebruiken, maar die mogen niet aanstaan in het begin, daardoor moeten ze
    //een frame na start uigezet worden
    bool started;

    void Update()
    {
        if(!started)
        {
            started = true;
            this.gameObject.SetActive(false);
        }
    }
}
