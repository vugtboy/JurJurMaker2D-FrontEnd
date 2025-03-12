using UnityEngine;

public class RotationGameModeFix : MonoBehaviour
{
    //kanonen kunnen roteren, in editmode kun je dit aanpassen, maar als je dan naar playmode gaat moet je die rotatie overzetten, dit gebeurt hier
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
