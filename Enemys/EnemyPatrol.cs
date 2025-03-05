using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
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
        if (AirCheck() || GroundCheck())
        {
            rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
        }
        if (AirCheck())
        {
            anim.SetBool("Falling", false);
            if (!GroundCheck() || WallCheck())
            {
                SwitchDirection();
            }
        }
        else
        {
            anim.SetBool("Falling", true);
        }
    }

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
