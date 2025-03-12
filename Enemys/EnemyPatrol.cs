using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //klasse die gaat over het lopen van de piraat
    public Rigidbody2D rb;
    public int direction;
    public float speed;
    public bool die;
    public Animator anim;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    public Transform airCheckPosition;
    public Transform wallCheck;
    public Vector3 wallCheckSize;

    void Update()
    {
        //om te mogen lopen moeten we niet vallen, maar als we een afgrond voor ons detecteren moeten we omdraaien aircheck checkt of we nog wel op de grond staan, terwijl groundcheck checkt of er voor ons een afgrond is
        if (AirCheck() || GroundCheck())
        {
            rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
        }
        //als we op de grond zijn moeten we niet vallen en omkeren als we tegen een ding aanlopen of er voor ons iets is
        if (AirCheck())
        {
            anim.SetBool("Falling", false);
            if (!GroundCheck() || WallCheck())
            {
                SwitchDirection();
            }
        }
        //als we in de lucht zijn vallen we
        else
        {
            anim.SetBool("Falling", true);
        }
    }
    //van richting veranderen
    void SwitchDirection()
    {
        if (direction == -1)
        {
            direction = 1;
            anim.SetBool("Right", false);
        }
        else
        {
            direction = -1;
            anim.SetBool("Right", true);
        }
    }

    bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheck.position, wallCheckSize, 0.2f, groundLayer);
    }

    bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPosition.position, 0.2f, groundLayer);
    }

    bool AirCheck()
    {
        return Physics2D.OverlapCircle(airCheckPosition.position, 0.2f, groundLayer);
    }
}
