using UnityEngine;

public class RemoveAndDestroy : MonoBehaviour
{
    //als er een object zich bevint op de positie van een point van een 2 hoog, dan het object verwijderen en uit de lijst halen
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
    //als we zelf gedelete worden de poinst uit de lijst halen en het object zelf uit de lijst met worldobjects van de saver halen(die gaat over het opslaan van de objecten in de game)
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
