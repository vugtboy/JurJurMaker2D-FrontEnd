using UnityEngine;

public class PlayAudioOnPlayDeath : MonoBehaviour
{
    public AudioSource audios;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeathBody"))
        {
            audios.Play();
        }
    }
}
