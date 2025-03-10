using UnityEngine;
using System.Collections;
public class CanonballMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public GameObject Object;
    void Start()
    {
        rb.linearVelocity = transform.right * -speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Block") || col.CompareTag("Box"))
        {
            Instantiate(Object, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if(col.CompareTag("Atack"))
        {
            Destroy(col.gameObject);
            Instantiate(Object, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if(col.CompareTag("DeathBody"))
        {
            Instantiate(Object, transform.position, transform.rotation);
            StartCoroutine(DestroyThis());
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
