using UnityEngine;

public class StrijdBlij : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startSpeed;
    public float bounceForce;
    public int bounces;
    public float existanceTime;
    public AudioSource bounceSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(startSpeed * transform.localScale.x, bounceForce);

    }

    // Update is called once per frame
    void Update()
    {
        existanceTime -= Time.deltaTime * 2;

        if(existanceTime < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Block") || col.gameObject.CompareTag("Box"))
        {
            existanceTime -= 1f;
            bounceSound.Play();
        }
    }
}
