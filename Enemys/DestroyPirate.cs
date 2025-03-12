using UnityEngine;

public class DestroyPirate : MonoBehaviour
{
    //bijde points van een pirate verwijderen(piraten werken anders dan de meeste 2hoge want deze moeten wel verwijderd worden als er een blok in zit)
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
