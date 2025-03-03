using UnityEngine;

public class FlameTrowerSwitchState : MonoBehaviour
{
    public FlameTrowerEditModeBehavior settings;
    public Animator anim;
    void OnEnable()
    {
        if(settings.flame)
        {
            anim.SetTrigger("flame");
        }
        else
        {
            anim.ResetTrigger("flame");
        }
    }
}
