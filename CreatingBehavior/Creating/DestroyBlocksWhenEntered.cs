using UnityEngine;

public class DestroyBlocksWhenEntered : MonoBehaviour
{
    //checkpoints en spelers mogen niet gedelete worden doordat blokken erin geplaatst worden, daarom deleten we het blok eerst
    private ObjectTypes Object;
    void Start()
    {
        Object = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void Update()
    {
        foreach (GameObject obj in Object.placedObjects)
        {
            if (obj.transform.position == transform.position)
            {
                if (obj.name != "point" && obj.name != "point2" && obj != transform.parent.parent.gameObject && obj != this.gameObject)
                {
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}
