using UnityEngine;

public class DeleteSoundPlay : MonoBehaviour
{
    public AudioSource deleteSound;
    void Start()
    {
        deleteSound = GameObject.Find("DeleteSound").GetComponent<AudioSource>();
    }
    void OnDestroy()
    {
        if (deleteSound != null)
        deleteSound.Play();
    }
}
