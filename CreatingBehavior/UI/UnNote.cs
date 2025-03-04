using UnityEngine;

public class UnNote : MonoBehaviour
{
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
