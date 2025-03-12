using UnityEngine;

public class FlameTrowerSwitchState : MonoBehaviour
{
    //belangrijk is dat de aan en uitwaarden doorgegeven worden aan het playobject die hem in het begin aan of uit zet
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
