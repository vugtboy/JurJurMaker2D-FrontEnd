using UnityEngine;

public class PlayAudioPerPlayer : MonoBehaviour
{
    //een audioclip spelen als de speler tegen dit object aanloopt, afhankelijk van welke speler er is geselecteerd
    private AudioSource audios;
    public AudioClip[] clips;
    private int player;
    private PlayerSelector playerSelector;
    public bool playedThisTime;
    public GameModeManager gm;
    void Start()
    {
        gm = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        playerSelector = GameObject.Find("Player").GetComponent<PlayerSelector>();
        audios = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gm.Play)
        {
            playedThisTime = false;
        }
        player = playerSelector.selectedPlayer;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !playedThisTime)
        {
            playedThisTime = true;
            audios.clip = clips[player];
            audios.Play();
        }
    }
}
