using UnityEngine;

public class ButtonMenuSwitch : MonoBehaviour
{
    //als je op een butten klikt switchen tussen 2 ui elementen
    public GameObject offWhenPressed;
    public GameObject onWhenPressed;

    public void Click()
    {
        offWhenPressed.SetActive(false);
        onWhenPressed.SetActive(true);
    }
}
