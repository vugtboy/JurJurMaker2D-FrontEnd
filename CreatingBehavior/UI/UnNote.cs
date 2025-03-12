using UnityEngine;

public class UnNote : MonoBehaviour
{
    //notificatie op animatieframe de wegga animatie laten spelen
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ResetNotefication()
    {
        anim.SetBool("Note", false);
    }
}
