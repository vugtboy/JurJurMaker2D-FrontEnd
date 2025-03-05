using UnityEngine;

public class CoinSoundPlay : MonoBehaviour
{
    public AudioSource coin;
    void OnDisable()
    {
        coin.Play();
    }
}
