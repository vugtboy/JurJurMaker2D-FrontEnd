using UnityEngine;

public class PlayAudioOnPlayDeath : MonoBehaviour
{
    //een audioclip afspelen als een dode speler interact met dit object
    public AudioSource audios;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeathBody"))
        {
            audios.Play();
        }
    }
}
