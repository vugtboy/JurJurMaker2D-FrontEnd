using UnityEngine;

public class RespawnPointMoverLayerFix : MonoBehaviour
{
    public SpriteRenderer sp1;
    public SpriteRenderer sp2;
    void OnMouseDown()
    {
        sp1.sortingOrder = 10;
        sp2.sortingOrder = 10;
    }

    void OnMouseUp() 
    {
        sp1.sortingOrder = 0;
        sp2.sortingOrder = 0;
    }
}
