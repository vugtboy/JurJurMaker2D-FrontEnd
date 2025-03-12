using UnityEngine;

public class PirateDeath : MonoBehaviour
{
    //voor een piraat dood te laten gaan en geluid af te spelen als een piraat dood gaat
    public GameObject pirateBody;
    public GameObject pirateBodyLeft;
    public GameObject deadme;
    private EnemyPatrol enemy;

    void Start()
    {
        enemy = GetComponent<EnemyPatrol>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Atack"))
        {
            Destroy(col.gameObject);
            this.gameObject.SetActive(false);
            if (enemy.direction == -1)
            {               
                deadme = Instantiate(pirateBody, transform.position, transform.rotation);
            }
            else
            {
                deadme = Instantiate(pirateBodyLeft, transform.position, transform.rotation);
            }
        }
    }
}
