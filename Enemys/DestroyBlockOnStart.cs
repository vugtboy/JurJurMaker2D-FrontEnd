using UnityEngine;

public class DestroyBlockOnStart : MonoBehaviour
{
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
