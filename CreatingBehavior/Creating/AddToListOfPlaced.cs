using UnityEngine;

public class AddToListOfPlaced : MonoBehaviour
{
    public ObjectTypes placed;
    void Start()
    {
        placed = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
        placed.placedObjects.Add(this.gameObject);
    }
}
