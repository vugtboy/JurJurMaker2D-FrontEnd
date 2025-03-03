using UnityEngine;

public class RemoveObjectFromPlacedList : MonoBehaviour
{
    public ObjectTypes placed;
    void Start()
    {
        placed = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
        placed.placedObjects.Remove(this.gameObject);
    }
}
