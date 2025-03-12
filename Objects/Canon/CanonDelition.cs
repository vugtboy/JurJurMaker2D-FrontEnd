using UnityEngine;

public class CanonDelition : MonoBehaviour
{
    //niet allen editkanon deleten maar juist de parent(voor alle blokken die switchen tussen modes is later gebleken)
    public ObjectTypes Objects;
    public GameObject Object;
    public WorldObject WorldObj;
    void Start()
    {
        Objects = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            WorldObj.Remove();
            Objects.placedObjects.Remove(Object);
            Destroy(Object);
        }
    }
}
