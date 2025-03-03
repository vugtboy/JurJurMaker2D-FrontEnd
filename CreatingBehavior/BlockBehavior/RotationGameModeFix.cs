using UnityEngine;

public class RotationGameModeFix : MonoBehaviour
{
    public GameModeManager ModeManager;

    public GameObject EditObject;
    public GameObject PlayObject;

    public bool previousState;
    void Start()
    {
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        previousState = ModeManager.Play;
    }
    void Update()
    {
        if (ModeManager.Play != previousState)
        {
            if (ModeManager.Play)
            {
                PlayObject.transform.eulerAngles = EditObject.transform.eulerAngles;
            }
            previousState = ModeManager.Play;
        }
    }
}
