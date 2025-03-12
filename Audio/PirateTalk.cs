using UnityEngine;
using System.Collections;
public class PirateTalk : MonoBehaviour
{
    //de piraten random laten praten en laten kiezen tussen 3 audioclips
    public AudioSource aud;
    public AudioClip[] ac;
    private float seconds;

    void OnEnable()
    {
        StartCoroutine("Talk");
    }

    void OnDisable()
    {
        StopCoroutine("Talk");
    }

    IEnumerator Talk()
    {
        seconds = Random.Range(5, 30);
        yield return new WaitForSeconds(seconds);
        int index = Random.Range(0, 3);
        aud.clip = ac[index];
        aud.Play();
        StartCoroutine("Talk");
    }

}
