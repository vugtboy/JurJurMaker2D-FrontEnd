using UnityEngine;
using System;
public class PirateMovement : MonoBehaviour
{
    public ObjectTypes placer;
    public float moveTimer;
    public bool selected;
    public Vector3 placePosition;
    public BlockAllignement myBlockAllignement;
    public SpriteRenderer sp;
    public int mainLayer;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        mainLayer = sp.sortingOrder;
        myBlockAllignement = GetComponent<BlockAllignement>();
        placer = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }
    void OnMouseDown()
    {
        placer.gameObject.SetActive(false);
        anim.SetBool("Lift", true);
        anim.SetTrigger("LiftUp");
        sp.sortingOrder = 10;
        if (myBlockAllignement != null)
        {
            myBlockAllignement.isMoving = true;
        }
        placer.isMovingBlock = true;
        selected = true;
    }

    void OnMouseUp()
    {
        anim.SetBool("Lift", false);
        sp.sortingOrder = mainLayer;
        if (myBlockAllignement != null)
        {
            myBlockAllignement.isMoving = false;
            myBlockAllignement.Fix();
        }
        placer.gameObject.SetActive(true);
        placer.isMovingBlock = false;
        if (moveTimer < 0)
        {
            Place();
        }
        selected = false;
    }

    void Update()
    {
        placePosition = new Vector3(MathF.Round(transform.position.x), MathF.Round(transform.position.y), 0);
        if (selected)
        {
            moveTimer -= Time.deltaTime;
        }
        else
        {
            moveTimer = 0.25f;
        }
        if (moveTimer < 0 && selected)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    void Place()
    {
        foreach (GameObject Object in placer.placedObjects)
        {
            if (Object.transform.position == placePosition)
            {
                if (Object.name == "point" || Object.name == "point2")
                {
                    break;
                }
                Destroy(this.gameObject);
                transform.position = placePosition;
                break;
            }
        }
        transform.position = placePosition;
    }
}
