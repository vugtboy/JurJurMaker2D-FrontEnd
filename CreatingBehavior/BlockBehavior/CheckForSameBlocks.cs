using UnityEngine;

public class CheckForSameBlocks : MonoBehaviour
{
    public BlockAllignement parrent;
    public int position;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            if (col.GetComponent<BlockAllignement>() != null && col.GetComponent<BlockAllignement>().type == parrent.type)
            {
                parrent.positions[position] = true;
                parrent.UpdateTexture();
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            if (col.GetComponent<BlockAllignement>() != null && col.GetComponent<BlockAllignement>().type == parrent.type)
            {
                parrent.UpdateTexture();
                parrent.positions[position] = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            if (col.GetComponent<BlockAllignement>() != null && col.GetComponent<BlockAllignement>().type == parrent.type)
            {
                parrent.positions[position] = false;
                parrent.UpdateTexture();
            }
        }
    }
}
