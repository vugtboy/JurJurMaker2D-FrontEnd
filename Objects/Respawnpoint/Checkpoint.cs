using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Respawner respawner;
    void Start()
    {
        respawner = GameObject.Find("Respawner").GetComponent<Respawner>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            respawner.checkPoint = true;
            respawner.respawnPoint = transform.position;
            int coins = col.GetComponent<CoinCounter>().Counter;
            respawner.Coins = coins;
            if (col.GetComponent<PlayerProjectiles>().hasAbility)
            {
                respawner.ability = true;
            }
        }
    }
}
