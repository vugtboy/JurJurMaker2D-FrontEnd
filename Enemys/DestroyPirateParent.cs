using UnityEngine;

public class DestroyPirateParent : MonoBehaviour
{
    public ObjectTypes Object;
    public GameObject[] objects;

    void Start()
    {
        Object = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
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
