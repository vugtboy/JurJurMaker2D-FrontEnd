using UnityEngine;

public class BoxFinder : MonoBehaviour
{
    public PickableObject box;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Box"))
        {
            box = col.GetComponent<PickableObject>();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Box"))
        {
            box = col.GetComponent<PickableObject>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Box") && col.GetComponent<PickableObject>() == box)
        {
            box = null;
        }
    }
}
