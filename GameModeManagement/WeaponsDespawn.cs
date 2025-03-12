using UnityEngine;

public class WeaponsDespawn : MonoBehaviour
{
    //wapens moeten verot gaan als de speler de ability heeft, je hebt er maar een, maar ook ability word in checkpoint opgeslagen, en als je die hebt mag je niet nog een keer ability kunnen krijgen
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
