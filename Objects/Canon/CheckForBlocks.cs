using UnityEngine;

public class CheckForBlocks : MonoBehaviour
{
    public CanonConnection connecter;
    public int checkNumber;
    bool inside;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Block"))
        {
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            inside = false;
        }
    }

    void Update()
    {
        if(inside)
        {
            connecter.UpdateConnection(checkNumber);
        }        
    }
}
