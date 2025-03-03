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
            if(col.GetComponent<PlayerProjectiles>().hasAbility)
            {
                respawner.ability = true;
            }
        }
    }
    void Update()
    {
        
    }
}
