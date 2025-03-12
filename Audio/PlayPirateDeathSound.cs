using UnityEngine;

public class PlayPirateDeathSound : MonoBehaviour
{
    //als de piraat doodgaat kiezen uit de juiste deathsounds
    public AudioSource aud;
    public AudioClip[] ac;
    void Start()
    {
        int index= Random.Range(0, 3);
        aud.clip = ac[index];
        aud.Play();
    }
}
