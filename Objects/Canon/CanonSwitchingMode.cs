using UnityEngine;

public class CanonSwitchingMode : MonoBehaviour
{
    public GameModeManager ModeManager;

    public GameObject EditObject;
    public GameObject PlayObject;
    public Transform EditObjectRotation;
    public GameObject PlayObjectRotation;
    void Start()
    {
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
    }
    void Update()
    {
        if (ModeManager.Play == false)
        {
            EditObject.SetActive(true);
            PlayObject.transform.position = transform.position;
            PlayObject.transform.eulerAngles = EditObject.transform.eulerAngles;
            PlayObjectRotation.transform.eulerAngles = EditObjectRotation.transform.eulerAngles;
            PlayObject.SetActive(false);
        }
        else
        {
            PlayObject.SetActive(true);
            EditObject.transform.position = transform.position;
            EditObject.SetActive(false);
        }
    }
}
