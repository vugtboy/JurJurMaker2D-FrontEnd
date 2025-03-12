using UnityEngine;

public class SawModeBehavior : MonoBehaviour
{
    //de zaag ressetten zodat hij altijd eerst naar punt 0 gaat en dan 1
    public Saw saw;
    public GameModeManager ModeManager;

    void Start()
    {
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
    }

    void Update()
    {
        if (ModeManager.Play == false)
        {
            saw.currentPos = 0;
        }
    }
}
