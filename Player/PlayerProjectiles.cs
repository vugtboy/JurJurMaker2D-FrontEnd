using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    public GameObject Projectile;
    public bool hasAbility;
    public float reShoot;
    public GameObject powerUp;
    public GameObject PowerTrumpet;
    void Update()
    {
        if(reShoot <= 0 && Input.GetKeyDown(KeyCode.W) && hasAbility)
        {
            GameObject prefab = Instantiate(Projectile, transform.position, transform.rotation);
            if(transform.localScale.x < 0)
            {
                prefab.transform.localScale = new Vector3(-1, 1, 0);
            }
            reShoot = 3;
        }
        if(reShoot >= 0)
        {
            reShoot -= Time.deltaTime;
        }
        if(!hasAbility)
        {
            Destroy(PowerTrumpet);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "StrijdBlij")
        {
            if (!hasAbility)
            {
                PowerTrumpet = Instantiate(powerUp, transform.position, transform.rotation);
                PowerTrumpet.transform.parent = transform;
            }
            hasAbility = true;
            col.gameObject.SetActive(false);
        }
    }
}
