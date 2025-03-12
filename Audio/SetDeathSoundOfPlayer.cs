using UnityEngine;

public class SetDeathSoundOfPlayer : MonoBehaviour
{
    //objecten een audioclip laten instellen als de speler doodgaat, dit zodat het per object een ander geluid is bv een spike = auch, de void = whaa!
    private AudioSource deathAudios;
    public AudioClip[] deathclip;
    private int player;
    private PlayerSelector playerSelector;
    void Start()
    {
        playerSelector = GameObject.Find("Player").GetComponent<PlayerSelector>();
        deathAudios = GameObject.Find("DeathSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        player = playerSelector.selectedPlayer;
    }


    void OnTriggerEnter2D(Collider2D col)
    {  
        if(col.gameObject.CompareTag("DeathBody"))
        {
            Destroy(col.gameObject);
            deathAudios.clip = deathclip[player];
            deathAudios.Play();
        }
    }
}
