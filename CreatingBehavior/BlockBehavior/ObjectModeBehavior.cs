using UnityEngine;

public class ObjectModeBehavior : MonoBehaviour
{
    public GameModeManager ModeManager;

    public GameObject EditObject;
    public GameObject PlayObject;

    public bool previousState;
    void Start()
    {
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        previousState = ModeManager.Play;
        if (!ModeManager.Play)
        {
            EditObject.SetActive(true);
            PlayObject.transform.position = transform.position;
            PlayObject.SetActive(false);
        }
    }
    void Update()
    {
        if (ModeManager.Play != previousState)
        {
            if (!ModeManager.Play)
            {
                EditObject.SetActive(true);
                PlayObject.transform.position = transform.position;
                PlayObject.SetActive(false);
            }
            else
            {
                PlayObject.SetActive(true);
                EditObject.transform.position = transform.position;
                EditObject.SetActive(false);
            }
            previousState = ModeManager.Play;
        }
    }
}
