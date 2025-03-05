using UnityEngine;

public class PlayAtackYellPerPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    private int player;
    private PlayerSelector playerSelector;
    public AudioSource audioSource;
    void Awake()
    {
        playerSelector = GameObject.Find("Player").GetComponent<PlayerSelector>();
        player = playerSelector.selectedPlayer;
        audioSource.clip = clips[player];
        audioSource.Play();
    }

    void Update()
    {
        audioSource.clip = clips[player];
    }
}
