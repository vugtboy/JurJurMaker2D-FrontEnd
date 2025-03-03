using UnityEngine;
using System;
using System.Collections.Generic;
public class PlayerEditMode : MonoBehaviour
{
    public ObjectTypes placer;
    public bool selected;
    public Vector3 placePosition;
    public SpriteRenderer sp;
    public int mainLayer;
    public GameObject EditPlayer;
    public GameObject Point;
    public GameObject Point2;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        mainLayer = sp.sortingOrder;
        placer = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
        placer.placedObjects.Add(Point2);
        placer.placedObjects.Add(Point);
    }
    void OnMouseDown()
    {
        placer.gameObject.SetActive(false);
        placer.isMovingBlock = true;
        sp.sortingOrder = 10;
        selected = true;
    }

    void OnMouseUp()
    {
        sp.sortingOrder = mainLayer;
        placer.gameObject.SetActive(true);
        placer.isMovingBlock = false;
        Place();
        selected = false;
    }

    void Update()
    {
        placePosition = new Vector3(MathF.Round(transform.position.x), MathF.Round(transform.position.y) + 0.5f, 0);
        if (selected)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            transform.position = new Vector3(MathF.Round(mousePos.x), MathF.Round(mousePos.y) +0.49f, mousePos.z);
        }

        foreach (GameObject Object in placer.placedObjects)
        {
            if (Object.transform.position == Point.transform.position && Object.name != "point" && Object.name != "point2")
            {
                Destroy(Object);
                placer.placedObjects.Remove(Object);
                break;
            }
            if (Object.transform.position == Point2.transform.position && Object.name != "point" && Object.name != "point2")
            {
                Destroy(Object);
                placer.placedObjects.Remove(Object);
                break;
            }
        }
    }

    void Place()
    {
        transform.position = placePosition;
        EditPlayer.transform.position = placePosition;
    }
}
