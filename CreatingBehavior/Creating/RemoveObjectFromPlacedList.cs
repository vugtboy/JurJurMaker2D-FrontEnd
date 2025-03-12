using UnityEngine;

public class RemoveObjectFromPlacedList : MonoBehaviour
{
    //een object verwijderen uit de geplaatst objectenlijst van de placer(dit voor de 2 hoge want daarbij gaat het alleen om hun points)
    public ObjectTypes placed;
    void Start()
    {
        placed = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
        placed.placedObjects.Remove(this.gameObject);
    }
}
