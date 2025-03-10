using UnityEngine;
using System.Collections;
public class Ending : MonoBehaviour
{
    private Animator anim;
    public AudioClip[] clips;
    private int player;
    private PlayerSelector playerSelector;
    private AudioSource audioSource;
    private GameObject music;
    void Start()
    {
        music = GameObject.Find("MusicGame");
        audioSource = GameObject.Find("VictorySound").GetComponent<AudioSource>();
        playerSelector = GameObject.Find("Player").GetComponent<PlayerSelector>();
        anim = GameObject.Find("#Finish").GetComponent<Animator>();
    }

    void Update()
    {
        player = playerSelector.selectedPlayer;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Tomato"))
        {
            music.SetActive(false);
            audioSource.clip = clips[player];
            audioSource.Play();
            anim.SetTrigger("Victory");
            transform.parent.gameObject.SetActive(false);
        }
    }
}
