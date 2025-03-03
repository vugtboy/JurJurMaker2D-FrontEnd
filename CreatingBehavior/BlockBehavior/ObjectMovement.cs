using UnityEngine;
using System;
public class ObjectMovement : MonoBehaviour
{
    public ObjectTypes placer;
    public float moveTimer;
    public bool selected;
    public Vector3 placePosition;
    public SpriteRenderer sp;
    public int mainLayer;
    public Animator anim;
    public Transform parentObject;
    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        mainLayer = sp.sortingOrder;
        placer = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }
    void OnMouseDown()
    {
        placer.gameObject.SetActive(false);
        anim.SetBool("Lift", true);
        anim.SetTrigger("LiftUp");
        sp.sortingOrder = 10;
        placer.isMovingBlock = true;
        selected = true;
    }

    void OnMouseUp()
    {
        anim.SetBool("Lift", false);
        sp.sortingOrder = mainLayer;
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
        placePosition = new Vector3(MathF.Round(parentObject.position.x), MathF.Round(parentObject.position.y), 0);
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
            parentObject.position = mousePos;
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
                placer.placedObjects.Remove(Object);
                Destroy(Object);
                parentObject.position = placePosition;
                break;
            }
        }
        parentObject.position = placePosition;
    }
}
