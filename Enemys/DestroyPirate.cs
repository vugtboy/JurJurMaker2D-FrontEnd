using UnityEngine;

public class DestroyPirate : MonoBehaviour
{
    public GameObject parent;
    public GameObject otherPoint;
    private ObjectTypes _placer;

    void Start()
    {
        _placer = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void OnDestroy()
    {
        _placer.placedObjects.Remove(this.gameObject);
        _placer.placedObjects.Remove(otherPoint);
        Destroy(parent);
    }
}
