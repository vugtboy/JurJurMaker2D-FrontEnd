using UnityEngine;

public class CheckForBlocks : MonoBehaviour
{ 
    //dit zit op 4 points om kanon heen om te checken of het kan verbinden en opdat de canononconnection code van dit kanon afhankelijk van de ingestelde point
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
