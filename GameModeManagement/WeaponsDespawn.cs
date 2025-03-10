using UnityEngine;

public class WeaponsDespawn : MonoBehaviour
{
    private PlayerProjectiles projectiles;
    void Start()
    {
        projectiles = GameObject.Find("PlayerObject").GetComponent<PlayerProjectiles>();
    }

    void Update()
    {
        if(projectiles.hasAbility)
        {
            this.gameObject.SetActive(false);
        }
    }
}
