using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool holded;
    public Transform holdpoint;
    public float trowSpeed;
    public Rigidbody2D rb;
    public Transform groundCheckPoint;
    public Transform wallCheckPoint;
    public LayerMask groundCheckLayer;
    public LayerMask wallCheckLayer;
    public Vector3 groundCheckSize;
    public float direction;
    public BoxCollider2D box;
    void Update()
    {
        //als we in een muur zijn geplaatst eruit gaan
        if(WallCheck())
        {
            transform.position = new Vector3 (transform.position.x -direction / 1.5f, transform.position.y + 1f, transform.position.z);
        }
        //als we vastgehouden worden zorgen dat we op het vasthoudtpunt van de speler zitten en niet colliden met deze
        if(holded)
        {
            box.enabled = false;
            transform.position = holdpoint.position;
        }
        else
        {
            box.enabled = true;
        }
    }
    //gooien
    public void Trow(float direction)
    {
        this.direction = direction;
        holded = false;
        rb.linearVelocity = new Vector3(trowSpeed * direction, 6);
    }

    bool Grounded()
    {
        return Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0.2f, groundCheckLayer);
    }

    bool WallCheck()
    {
        return Physics2D.OverlapCircle(wallCheckPoint.position, 0.2f, wallCheckLayer);
    }
}
