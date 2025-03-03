using UnityEngine;

public class TurnOfAfterStart : MonoBehaviour
{
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
