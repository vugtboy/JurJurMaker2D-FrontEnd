using UnityEngine;

public class SpikeBallSwitchingMode : MonoBehaviour
{
    public GameModeManager ModeManager;

    public GameObject EditObject;
    public GameObject PlayObject;
    public Transform EditObjectTransform;
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
            PlayObject.transform.localScale = EditObject.transform.localScale;
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
