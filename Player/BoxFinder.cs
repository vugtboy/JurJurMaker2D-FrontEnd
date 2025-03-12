using UnityEngine;

public class BoxFinder : MonoBehaviour
{
    //als de speler voor een doos staat dan deze doos hier tijdelijk opslaan
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
