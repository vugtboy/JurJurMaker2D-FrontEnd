using UnityEngine;

public class MapSize : MonoBehaviour
{
    public int maxLength = 199;
    public int maxHeigth = 99;

    public void UpdateWorldSize(int maxHeigth, int maxLength)
    {
        this.maxLength = maxLength;
        this.maxHeigth = maxHeigth;
    }    
}
