using UnityEngine;

public class GroundTypeChecker : MonoBehaviour
{
    public PlayerBehavior player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BlockAllignement>() != null && col.GetComponent<BlockAllignement>().type == "Ice")
        {
            player.sliperyness = 1;
            player.airFriction = 2.25f;
        }
        else
        {
            player.sliperyness = 4;
            player.airFriction = 2.5f;
        }
    }
}
