using UnityEngine;

public class ButtonMenuSwitch : MonoBehaviour
{
    public GameObject offWhenPressed;
    public GameObject onWhenPressed;

    public void Click()
    {
        offWhenPressed.SetActive(false);
        onWhenPressed.SetActive(true);
    }
}
