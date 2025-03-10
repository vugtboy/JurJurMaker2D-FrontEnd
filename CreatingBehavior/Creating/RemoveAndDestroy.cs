using UnityEngine;

public class RemoveAndDestroy : MonoBehaviour
{
    public ObjectTypes Object;
    public GameObject[] objects;

    public GameObject Point;
    public GameObject Point2;
    public WorldObject WorldObj;
    void Start()
    {
        Object = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void Update()
    {
        foreach (GameObject Objectr in Object.placedObjects)
        {
            if (Objectr.transform.position == Point.transform.position && Objectr.name != "point" && Objectr.name != "point2")
            {
                Destroy(Objectr);
                Object.placedObjects.Remove(Objectr);
                break;
            }
            if (Objectr.transform.position == Point2.transform.position && Objectr.name != "point" && Objectr.name != "point2")
            {
                Destroy(Objectr);
                Object.placedObjects.Remove(Objectr);
                break;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            WorldObj.Remove();
            foreach (GameObject gameObject in objects)
            {
                Destroy(gameObject);
                Object.placedObjects.Remove(gameObject);
            }
            Object.placedObjects.Remove(this.gameObject);
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
