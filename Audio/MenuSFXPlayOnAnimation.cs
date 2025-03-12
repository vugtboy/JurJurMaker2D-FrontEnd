using UnityEngine;

public class MenuSFXPlayOnAnimation : MonoBehaviour
{
    //om geluiden af te spelen via animatie keys
    public AudioSource Aud1;
    public AudioSource Aud2;
    public AudioSource Aud3;
    public AudioSource Aud4;
    public AudioSource Aud5;
    public void Play1()
    {
        Aud1.Play();
    }

    public void Play2()
    {
        Aud2.Play();
    }

    public void Play3()
    {
        Aud3.Play();
    }

    public void Play4()
    {
        Aud4.Play();
    }

    public void Play5()
    {
        Aud5.Play();
    }
}
