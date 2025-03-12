using UnityEngine;

public class DeleteSoundPlay : MonoBehaviour
{
    //een geluid spelen waneer een object gedelete word
    public AudioSource deleteSound;
    void Start()
    {
        deleteSound = GameObject.Find("DeleteSound").GetComponent<AudioSource>();
    }
    void OnDestroy()
    {
        if (deleteSound != null && deleteSound.enabled == true && deleteSound.gameObject.activeSelf)
        {
            deleteSound.Play();
        }
    }
}
