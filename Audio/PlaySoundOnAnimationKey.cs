using UnityEngine;

public class PlaySoundOnAnimationKey : MonoBehaviour
{
    public AudioSource aud;
    public AudioSource aud2;
    public void PlayAudio()
    {
        aud.Play();
    }
    public void PlayAudio2()
    {
        aud2.Play();
    }
}
