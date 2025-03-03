using UnityEngine;

public class CanonDelition : MonoBehaviour
{
    public ObjectTypes Objects;
    public GameObject Object;
    void Start()
    {
        Objects = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            Objects.placedObjects.Remove(Object);
            Destroy(Object);
        }
    }
}
