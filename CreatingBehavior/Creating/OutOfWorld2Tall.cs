using UnityEngine;

public class OutOfWorld2Tall : MonoBehaviour
{
    public MapSize mapSize;
    public ObjectTypes Objects;
    public GameObject point1;
    public GameObject point2;
    void Start()
    {
        mapSize = GameObject.Find("MapSizeEditor").GetComponent<MapSize>();
        Objects = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void Update()
    {
        if (NotInWorld() && !Input.GetMouseButton(0))
        {
            Objects.placedObjects.Remove(this.gameObject);
            Objects.placedObjects.Remove(point1);
            Objects.placedObjects.Remove(point2);
            Destroy(this.gameObject);
        }
    }

    bool NotInWorld()
    {
        if (transform.position.x < 0 || transform.position.x > mapSize.maxLength || transform.position.y < 0 || transform.position.y > mapSize.maxHeigth)
            return true;
        else return false;
    }
}
