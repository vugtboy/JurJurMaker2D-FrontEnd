using UnityEngine;

public class SetEditButtons : MonoBehaviour
{
    public GameObject editMode1;
    public GameObject editMode2;
    public GameObject exit;
    void Start()
    {
        if(GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>().playModeOnly)
        {
            editMode1.SetActive(false);
            Destroy(editMode2);
            exit.SetActive(true);
        }
        else
        {
            exit.SetActive(false);
        }
    }

}
