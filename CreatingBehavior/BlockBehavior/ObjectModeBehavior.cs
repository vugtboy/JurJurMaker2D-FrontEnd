using UnityEngine;

public class ObjectModeBehavior : MonoBehaviour
{
    //wisselen tussen playmode object en edit object, omdat bijde heel anders zijn, kannon schieten en spikeballs draaien in play, in edit wil je ze aan kunnen passen
    //hierdoor heb ik ze een verschillend object gegeven, wat het makkelijk maakt om ertussen te wisselen
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
