using UnityEngine;

public class DestroyBlockOnStart : MonoBehaviour
{
    //als tweehoge blokken geplaatst worden wordt gekeken of het in het blok boven het geplaatste blok(want 2 hoog) een blok is (zoja, delete!)
    private ObjectTypes Object;

    void Start()
    {
        Object = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
        foreach(GameObject obj in Object.placedObjects)
        {
            if (obj.transform.position == transform.position)
            {
                if (obj.name != "point" && obj.name != "point2" && obj != transform.parent.parent.gameObject && obj != this.gameObject)
                {
                    Object.placedObjects.Remove(obj);
                    Destroy(obj);
                    break;
                }
            }
        }
    }
}
