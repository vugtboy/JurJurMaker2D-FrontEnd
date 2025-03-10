using UnityEngine;

public class BackGroundSetter : MonoBehaviour
{
    public GameObject[] BackGrounds;
    private TemporaryWorldStorer world;
    void Start()
    {
        world = GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>();
        SetBackGround(world.world.background);
    }

    public void SetBackGround(int index)
    {
        foreach (GameObject bg in BackGrounds)
        {
            bg.SetActive(false);
        }
        world.world.background = index;
        BackGrounds[index].gameObject.SetActive(true);
    }
}
