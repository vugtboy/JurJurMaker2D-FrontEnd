using UnityEngine;

public class PointDestroyment : MonoBehaviour
{
    public ObjectTypes placed;

    void Start()
    {
        placed = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void OnDestroy()
    {
        Debug.Log("Destroy");
        placed.placedObjects.Remove(this.gameObject);
        Destroy(transform.parent);
    }
}
