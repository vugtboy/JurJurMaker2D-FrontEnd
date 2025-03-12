using UnityEngine;

public class PointDestroyment : MonoBehaviour
{
    //een object verwijderen uit de placedobjectlist, als je een object verwijdert van 2 hoog
    public ObjectTypes placed;

    void Start()
    {
        placed = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void OnDestroy()
    {
        placed.placedObjects.Remove(this.gameObject);
        Destroy(transform.parent);
    }
}
