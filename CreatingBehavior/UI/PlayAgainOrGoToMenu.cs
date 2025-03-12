using UnityEngine;

public class PlayAgainOrGoToMenu : MonoBehaviour
{
    //de knoppen om opnieuw te spelen of te editen als je klaar bent met spelen
    public Respawner respawner;
    void Start()
    {
        respawner = GameObject.Find("Respawner").GetComponent<Respawner>();
    }
    public void Play()
    {
        respawner.Respawn();
        GetComponent<Animator>().SetBool("Play", true);
    }

    public void Edit()
    {
        GetComponent<Animator>().SetBool("Play", true);
    }
}
