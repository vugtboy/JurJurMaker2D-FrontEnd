using UnityEngine;

public class PlayAtackYellPerPlayer : MonoBehaviour
{
    //de speler laten roepen als hij een wapen heeft bemachtigd, dit is voor elke speler een ander geluid
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
