using UnityEngine;

public class RespawnPointMoverLayerFix : MonoBehaviour
{
    //checkpoint bestaat uit 2 sprites, als het checkpoint opgetilt word wil je dat bijde voor de rest vna de game gerenderd worden
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
