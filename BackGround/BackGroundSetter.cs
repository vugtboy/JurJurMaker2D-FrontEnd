using UnityEngine;

public class BackGroundSetter : MonoBehaviour
{
    public GameObject[] BackGrounds;

    public void SetBackGround(int index)
    {
        foreach (GameObject bg in BackGrounds)
        {
            bg.SetActive(false);
        }
        BackGrounds[index].gameObject.SetActive(true);
    }
}
