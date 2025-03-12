using UnityEngine;

public class MapSize : MonoBehaviour
{
    //mapgroote aan kunnen passen in game, en deze goed instellen op de worldstorer voor als je de wereld opslaat
    public int maxLength = 199;
    public int maxHeigth = 99;
    private TemporaryWorldStorer world;
    void Start()
    {
        world = GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>();
        maxHeigth = world.world.maxHeigth;
        maxLength = world.world.maxLength;
    }
    public void UpdateWorldSize(int maxHeigth, int maxLength)
    {
        this.maxLength = maxLength;
        this.maxHeigth = maxHeigth;
        world.world.maxLength = maxLength;
        world.world.maxHeigth = maxHeigth;
    }    
}
