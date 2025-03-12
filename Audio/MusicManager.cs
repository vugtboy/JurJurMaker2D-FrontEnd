using UnityEngine;
using System.Collections;
public class MusicManager : MonoBehaviour
{
    //muziek op de juiste manier afspelen
    public AudioSource GameMusic;
    public AudioSource PreviewMusic;
    public AudioClip[] clips;

    private GameModeManager modeManager;
    private bool click;
    private TemporaryWorldStorer world;
    void Start()
    {
        modeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        world = GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>();
        GameMusic.clip = clips[world.world.music];
    }
    //de muziek in game veranderen naar gekozen muziek
    public void UpdateMusic(int index)
    {
        world.world.music = index;
        GameMusic.clip = clips[index];
        PreviewMusic.clip = clips[index];
        StopCoroutine("Preview");
        StartCoroutine("Preview");
    }
    //switchen tussen de bouwmuziek en speelmuziek
    void Update()
    {
        if(modeManager.Play != click)
        {
            if(!click)
            {
                GameMusic.gameObject.SetActive(true);
                click = true;
            }
            else
            {
                click = false;
            }
        }
        if(!modeManager.Play)
        {
            GameMusic.gameObject.SetActive(false);
        }
    }
    //een preview van muziek afspelen als je een nieuw muziekje kiest
    IEnumerator Preview()
    {
        PreviewMusic.Play();
        yield return new WaitForSeconds(8);
        PreviewMusic.Stop();
    }
}
