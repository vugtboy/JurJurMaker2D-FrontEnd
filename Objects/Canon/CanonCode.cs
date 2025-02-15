using UnityEngine;

public class CanonCode : MonoBehaviour
{
    public GameObject CanonBowl;
    public void Create()
    {
        Instantiate(CanonBowl, transform.position, transform.rotation);
    }
}
