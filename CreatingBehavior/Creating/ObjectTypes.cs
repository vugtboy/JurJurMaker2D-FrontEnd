using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class ObjectTypes : MonoBehaviour
{
    public GameObject[] allObjects;
    public int selected;
    public bool canPlaceHere;
    public Vector3 CreatePosition;
    public List<GameObject> placedObjects;
    public SpriteRenderer selectedBlockTexture;
    public bool isplacing;
    public bool isMovingBlock;
    private VisualObjectList inventory;
    private Animator notification;
    public AudioSource placeSound;
    void Start()
    {
        notification = GameObject.Find("#Notefication").GetComponent<Animator>();
        inventory = GameObject.Find("InventoryList").GetComponent<VisualObjectList>();
        canPlaceHere = true;
        selected = 1;
    }

    void Update()
    {
        inventory.Selected = selected;
        if(Input.GetMouseButtonUp(0))
        {
            isplacing = false;
        }
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = mousePos;
        CreatePosition = new Vector3(MathF.Round(transform.position.x), MathF.Round(transform.position.y), 0);
        if(Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {    
            if (CheckIfCanPlace() && !LimetedItemMax())
            {
                placeSound.Play();
                GameObject obj = Instantiate(allObjects[selected], CreatePosition, Quaternion.identity);
                placedObjects.Add(obj);
            }            
        }
        if (Input.GetMouseButtonDown(0) && LimetedItemMax() && CheckIfCanPlace())
        {
            notification.SetBool("Note", true);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0)
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
            if (selected < allObjects.Length - 1)
            {
                selected++;
            }
            else
            {
                selected = 0;
            }
        }
        selectedBlockTexture.sprite = inventory.Objects[selected].GetComponent<Image>().sprite;
    }

    bool CheckIfCanPlace()
    {
        foreach (GameObject Object in placedObjects)
        {
            if (Object.transform.position == CreatePosition)
            {
                if(Object.GetComponent<BlockAllignement>() != null)
                {
                    if (Object.GetComponent<BlockAllignement>().type == allObjects[selected].GetComponent<BlockAllignement>().type)
                    {
                        return false;
                    }
                    else if (Object.GetComponent<BlockAllignement>().type != allObjects[selected].GetComponent<BlockAllignement>().type && !isplacing)
                    {
                        return false;
                    }
                    else if (isplacing && Object.GetComponent<BlockAllignement>().type != allObjects[selected].GetComponent<BlockAllignement>().type)
                    {
                        placedObjects.Remove(Object);
                        Destroy(Object);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        isplacing = true;
        return true;
    }

    bool LimetedItemMax()
    {
        foreach (GameObject Object in placedObjects)
        {
            if(Object.CompareTag("Weapon") && selected == 11)
            {
                return true;
            }
            if (Object.CompareTag("Egg") && selected == 12)
            {
                return true;
            }
            if (Object.CompareTag("Ending") && selected == 15)
            {
                return true;
            }
        }
        return false;
    }
}
