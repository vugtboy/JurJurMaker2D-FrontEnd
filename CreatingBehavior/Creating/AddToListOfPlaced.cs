using UnityEngine;

public class AddToListOfPlaced : MonoBehaviour
{
    //toevoegen aan de lijst met geplaatste objecten van de placer voor object(points vna tweehoge objecten)
    public ObjectTypes placed;
    void Start()
    {
        placed = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
        placed.placedObjects.Add(this.gameObject);
    }
}
