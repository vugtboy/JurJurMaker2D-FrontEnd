using UnityEngine;

public class PlaySoundOnAnimationKey : MonoBehaviour
{
    //op een animatie keyframe een sound afspelen, 2 gedaan voor het geval je er meer dan 2 wil, het nadeel aan animatie keyframes is dat ze alleen
    //bij code kunnen waardoor je niet direct een audiosource kunt afspelen, wat wel met buttons kan
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
