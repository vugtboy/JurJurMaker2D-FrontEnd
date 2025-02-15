using UnityEngine;
using System;
using System.Collections.Generic;
public class ObjectTypes : MonoBehaviour
{
    public GameObject currentSelected;
    public GameObject[] allObjects;
    public int selected;
    public bool canPlaceHere;
    public Vector3 CreatePosition;
    public List<GameObject> placedObjects = new List<GameObject>();
    public SpriteRenderer selectedBlockTexture;
    void Start()
    {
        canPlaceHere = true;
        selected = 1;
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = mousePos;
        CreatePosition = new Vector3(MathF.Round(transform.position.x), MathF.Round(transform.position.y), 0);
        if (Input.GetMouseButton(0))
        {    
            if (CheckIfCanPlace())
            {
                placedObjects.Add(Instantiate(allObjects[selected], CreatePosition, Quaternion.identity));
            }
        }
    }

    bool CheckIfCanPlace()
    {
        foreach(GameObject Object in placedObjects)
        {
            if(Object.transform.position == CreatePosition)
            {
                if(Object.GetComponent<BlockAllignement>().type == allObjects[selected].GetComponent<BlockAllignement>().type)
                {
                    return false;
                }
                else
                {
                    placedObjects.Remove(Object);
                    Destroy(Object);
                    return true;
                }
            }
        }
        return true;
    }
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll < 0)
        {
            if (selected > 0)
            {
                selected--;
            }
            else
            {
                selected = allObjects.Length - 1;
            }
        }
        else if (scroll > 0)
        {
            if(selected < allObjects.Length - 1)
            {
                selected++;
            }
            else
            {
                selected = 0;
            }
        }  
        selectedBlockTexture.sprite = allObjects[selected].GetComponent<SpriteRenderer>().sprite;
    }

}
