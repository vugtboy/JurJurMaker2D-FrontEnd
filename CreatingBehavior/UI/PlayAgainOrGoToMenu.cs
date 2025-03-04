using UnityEngine;

public class PlayAgainOrGoToMenu : MonoBehaviour
{
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
