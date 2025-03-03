using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float actualSpeed;
    public float jumpSpeed;
    public Transform GroundCheckPosition;
    public LayerMask GroundLayer;
    public LayerMask WallLayer;
    public Transform WallCheckPosition;
    public Transform WallCheckBackPosition;
    public Vector3 WallCheckSize;
    public Transform WallSlideCheckPosition;
    public Vector3 WallSlideCheckSize;
    public Animator anim;
    public float sliperyness;
    float scaleSize;
    public float jumpAgainTimer = 0.1f;
    public float coyoteTime = 0.05f;
    public float maximalFallSpeedWhileSliding;
    public bool wall;
    public float direction;
    public bool isWallJumping;
    public float wallJumpMovementCooldown;
    public bool holdingBox;
    public BoxFinder boxFinder;
    public Transform BoxHoldingPoint;
    public PickableObject box;
    public float airFriction;
    public GameObject deathPlayer;
    public Respawner respawner;
    public LayerMask Bad;
    public Transform BadLayerCheckPosition;
    public Vector3 BadLayerCheckSize;
    public GameObject myDeathBody;
    void Start()
    {
        respawner = GameObject.Find("Respawner").GetComponent<Respawner>();
        scaleSize = transform.localScale.x;
    }

    void Update()
    {
        //doodgaan
        if (EnemyCheck())
        {
            Die();
        }
        //doos alleen optillen als je een doos voor je hebt staan
        if (GroundCheck() && Input.GetKeyDown(KeyCode.LeftShift) && boxFinder.box != null && !holdingBox)
        {
            holdingBox = true;
            this.box = boxFinder.box;
            box.holdpoint = BoxHoldingPoint;
            box.holded = true;
            anim.SetBool("HasBox", true);
        }
        //doos alleen optillen als je een doos voor je hebt staan
        if (GroundCheck() && Input.GetKey(KeyCode.LeftShift) && boxFinder.box != null && !holdingBox)
        {
            holdingBox = true;
            this.box = boxFinder.box;
            box.holdpoint = BoxHoldingPoint;
            box.holded = true;
            anim.SetBool("HasBox", true);
        }
        //box alleen gooien als we er een beet hebben
        if (Input.GetKeyUp(KeyCode.LeftShift) && holdingBox && box != null)
        {
            holdingBox = false;
            box.Trow(direction);
            box = null;
            anim.SetBool("HasBox", false);
        }
        //als je na het waljumpen om wilt draaien is er heel even om ervoor te zorgen dat je niet gelijk omdraait
        if(wallJumpMovementCooldown > 0)
        {
            wallJumpMovementCooldown -= Time.deltaTime;
        }
        //nadat je waljumpt word je echt gelauncht! en dan moet je snel afremmen om ongelukken te voorkomen
        if(actualSpeed < -speed)
        {
            actualSpeed += Time.deltaTime * 5;
        }
        if(actualSpeed > speed)
        {
            actualSpeed -= Time.deltaTime * 5;
        }
        wall = WallCheck();

        //richting bepalen
        if (transform.localScale.x > 0)
            direction = 1;
        else
            direction = -1;
        //wallsliden als je omlaag gaan
        if (WallCheck() && !GroundCheck() && !holdingBox)
        {
            //alleen sliden als we de juiste kant op kijken en op de juiste knop drukken
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                if (rb.linearVelocity.y < maximalFallSpeedWhileSliding && WallSlideCheck())
                {
                    //corigeren wanneer we te snel vallen alleen als we wallsliden
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, maximalFallSpeedWhileSliding);
                }
                //alleen sliden als we omlaag gaan & als we op juiste hoogte zijn tenopzichte van de muur zodat het armpje niet al te gek is
                if (rb.linearVelocity.y < 0 && WallSlideCheck())
                {
                    anim.SetBool("WallSlide", true);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("WallJump");
                    wallJumpMovementCooldown = 0.3f;
                    isWallJumping = true;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed / 1.2f);
                    actualSpeed = speed * -direction;
                    if (direction == -1)
                    {
                        transform.localScale = new Vector3(scaleSize, scaleSize, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-scaleSize, scaleSize, 1);
                    }
                }
            }
        }
        else if(!WallCheck() || GroundCheck())
        {
            anim.SetBool("WallSlide", false);
            isWallJumping = false;
        }
        //ervoor zorgen dat de speler pas een tweede keer mag springen nadat hij in de lucht is geweest
        if(!GroundCheck())
        {
            jumpAgainTimer = 0.1f;
            anim.SetBool("Jump", true);
            coyoteTime -= Time.deltaTime;
        }
        else
        {
            coyoteTime = 0.05f;
            anim.SetBool("Jump", false);
        }
        //springen
        if(Input.GetKeyDown(KeyCode.Space) && jumpAgainTimer >= 0.1f)
        {
            if(coyoteTime > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
                jumpAgainTimer = 0;
            }
        }
        //kijken of er nog een keer gesprongen mag worden om spammen te voorkomen
        if (jumpAgainTimer < 0.1f)
        {
            jumpAgainTimer += Time.deltaTime;
        }
        //niet lopen omdat beide kanten op gelopen moet worden
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (wallJumpMovementCooldown <= 0)
            {
                //in de lucht moet het afremmen veel langzamer gebeuren
                if (!GroundCheck())
                {
                    if (actualSpeed > 0)
                        actualSpeed -= Time.deltaTime * airFriction;
                    if (actualSpeed < 0)
                        actualSpeed += Time.deltaTime * airFriction;
                }
                //als hij op de grond is remt hij veel sneller af
                else
                {
                    if (actualSpeed > 0)
                        actualSpeed -= Time.deltaTime * 5 * sliperyness;
                    if (actualSpeed < 0)
                        actualSpeed += Time.deltaTime * 5 * sliperyness;
                    //snelheid naar absoluut nul zetten als hij niet wil lopen
                    if (actualSpeed > -0.25f && actualSpeed < 0.25f)
                        actualSpeed = 0;
                }
                //als je tegen een muur aan loopt snelheid verminderen om niet te blijven plakken
                if (WallCheck())
                {
                    if (direction == -1 && !isWallJumping && actualSpeed < 0)
                    {
                        actualSpeed = 0;
                    }
                    else if (direction == 1 && !isWallJumping && actualSpeed > 0)
                    {
                        actualSpeed = 0;
                    }
                }
                //als je met je rug tegen een muur aanloopt zorgen dat de snelheid nul word
                else if (WallBackCheck())
                {
                    if (direction == -1 && !isWallJumping && actualSpeed < 0)
                    {
                        actualSpeed = 0;
                    }
                    else if (direction == 1 && !isWallJumping && actualSpeed > 0)
                    {
                        actualSpeed = 0;
                    }
                }
            }
        }
        //lopen naar rechts
        else if (Input.GetKey(KeyCode.D))
        {
            if (!WallCheck() && direction == 1)
            {
                //sneller afremmen als op grond
                if (GroundCheck())
                {
                    if (actualSpeed < 0)
                    {
                        actualSpeed += Time.deltaTime * 10 * sliperyness;
                    }
                    else if (actualSpeed < speed)
                    {
                        actualSpeed += Time.deltaTime * 5 * sliperyness;
                    }
                }
                //want de gladheid van de grond telt niet in de lucht
                else
                {
                    if (actualSpeed < 0)
                    {
                        actualSpeed += Time.deltaTime * 10 * airFriction;
                    }
                    else if (actualSpeed < speed)
                    {
                        actualSpeed += Time.deltaTime * 5 * airFriction;
                    }
                }
            }
            else if (direction == 1 && !isWallJumping)
            {
                actualSpeed = 0;
            }
            //pas draaien als we niet aan het waljumpen zijn
            if (wallJumpMovementCooldown <= 0)
                transform.localScale = new Vector3(scaleSize, scaleSize, 1);
        }
        //lopen naar links
        else if (Input.GetKey(KeyCode.A))
        {
            if (!WallCheck() && direction == -1)
            {
                //sneller afremmen als op grond
                if (GroundCheck())
                {
                    if (actualSpeed > 0)
                    {
                        actualSpeed -= Time.deltaTime * 10 * sliperyness;
                    }
                    else if (actualSpeed > -speed)
                    {
                        actualSpeed -= Time.deltaTime * 5 * sliperyness;
                    }
                }
                //want de gladheid van de grond telt niet in de lucht
                else
                {
                    if (actualSpeed > 0)
                    {
                        actualSpeed -= Time.deltaTime * 10 * airFriction;
                    }
                    else if (actualSpeed > -speed)
                    {
                        actualSpeed -= Time.deltaTime * 5 * airFriction;
                    }
                }
            }
            else if (direction == -1 && !isWallJumping)
            {
                actualSpeed = 0;
            }
            //pas draaien als we niet aan het waljumpen zijn
            if (wallJumpMovementCooldown <= 0)
                transform.localScale = new Vector3(-scaleSize, scaleSize, 1);
        } 
        //kijken of de sneleheid hoog genoeg is voor de loopanimatie
        if(actualSpeed > -0.5f &&  actualSpeed < 0.5f)
        {
            anim.SetBool("Walking", false);      
        }
        else
        {
            anim.SetBool("Walking", true);
        }
        rb.linearVelocity = new Vector2(actualSpeed, rb.linearVelocity.y);
    }

    bool GroundCheck()
    {
        return Physics2D.OverlapCircle(GroundCheckPosition.position, 0.2f, GroundLayer);
    }

    bool WallCheck()
    {
        return Physics2D.OverlapBox(WallCheckPosition.position, WallCheckSize, 0.2f, WallLayer);
    }

    bool WallBackCheck()
    {
        return Physics2D.OverlapBox(WallCheckBackPosition.position, WallCheckSize, 0.2f, WallLayer);
    }

    bool WallSlideCheck()
    {
        return Physics2D.OverlapBox(WallSlideCheckPosition.position, WallSlideCheckSize, 0.2f, WallLayer);
    }

    bool EnemyCheck()
    {
        return Physics2D.OverlapBox(BadLayerCheckPosition.position, BadLayerCheckSize, 0.2f, Bad);
    }

    public void Die()
    {
        myDeathBody = Instantiate(deathPlayer, new Vector3(transform.position.x + 0.05f, transform.position.y, 0), transform.rotation);
        myDeathBody.transform.localScale = new Vector3(0.8666667f * direction, 0.8666667f, 0);
        transform.parent.gameObject.SetActive(false);
        if(holdingBox)
        {
            holdingBox = false;
            box.Trow(direction);
            box = null;
            anim.SetBool("HasBox", false);
        }        
        respawner.Respawn();
    }
}
