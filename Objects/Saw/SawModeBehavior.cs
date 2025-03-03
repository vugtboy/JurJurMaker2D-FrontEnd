using UnityEngine;

public class SawModeBehavior : MonoBehaviour
{
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
