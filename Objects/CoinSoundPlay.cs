using UnityEngine;

public class CoinSoundPlay : MonoBehaviour
{
    //als je een coin pakt een geluidje spelen
    public AudioSource coin;
    void OnDisable()
    {
        coin.Play();
    }
}
