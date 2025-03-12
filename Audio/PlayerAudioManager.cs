using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    //voor elke speler een geluid om te springen en om te atacken afspelen
    public AudioClip[] JumpSoundsJurJur;
    public AudioClip[] JumpSoundsAnton;
    public AudioClip[] JumpSoundsStumpy;
    public AudioClip[] atackSoundsJurJur;
    public AudioClip[] atackSoundsAnton;
    public AudioClip[] atackSoundsStumpy;

    private int lastJumpIndex;
    private AudioSource audios;
    private AudioSource deathAudios;
    private int lastAtackIndex;
    void Start()
    {
        deathAudios = GameObject.Find("DeathSound").GetComponent<AudioSource>();
        audios = GetComponent<AudioSource>();
    }
    //kijken welke speler geselecteerd is en hierop een van de juiste 3 random jumpsounds afspelen
    public void PlayJumpSound(int player)
    {
        int index = Random.Range(0, 3);
        while (index == lastJumpIndex)
        {
            index = Random.Range(0, 3);
        }
        if (player == 0)
            audios.clip = JumpSoundsJurJur[index];
        else if (player == 1)
            audios.clip = JumpSoundsAnton[index];
        else if (player == 2)
            audios.clip = JumpSoundsStumpy[index];
        audios.Play();
        lastJumpIndex = index;
    }
    //de juiste atacksound per speler kiezen
    public void PlayAtackSound(int player)
    {
        int index = Random.Range(0, 3);
        while (index == lastAtackIndex)
        {
            index = Random.Range(0, 3);
        }
        if (player == 0)
            audios.clip = atackSoundsJurJur[index];
        else if (player == 1)
            audios.clip = atackSoundsAnton[index];
        else if (player == 2)
            audios.clip = atackSoundsStumpy[index];
        audios.Play();
        lastAtackIndex = index;
    }
    //als de speler doodgaat een deathsound die door het aangeraakte object ingesteld is afspelen
    public void PlayDeathSound()
    {
        deathAudios.Play();
    }
}
