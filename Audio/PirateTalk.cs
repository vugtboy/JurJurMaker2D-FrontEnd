using UnityEngine;
using System.Collections;
public class PirateTalk : MonoBehaviour
{
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
