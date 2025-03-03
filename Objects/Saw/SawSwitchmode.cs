using UnityEngine;

public class SawSwitchmode : MonoBehaviour
{
    public bool horizontal;
    public Sprite[] textures;
    public SpriteRenderer sp;
    public GameObject Saw;
    public bool selected;
    public float isMoving;
    void Update()
    {
        if (selected)
        {
            isMoving -= Time.deltaTime;
        }
        else
        {
            isMoving = 0.25f;
        }
    }
    void OnMouseDown()
    {
        selected = true;
    }

    void OnMouseUp()
    {
        if (isMoving > 0)
        {
            SwitchMode();
        }
        selected = false;
    }

    void SwitchMode()
    {
        if (horizontal)
        {
            Saw.transform.eulerAngles = new Vector3(0, 0, 0);
            horizontal = false;
            sp.sprite = textures[0];
        }
        else
        {
            Saw.transform.eulerAngles = new Vector3(0, 0, 90);
            horizontal = true;
            sp.sprite = textures[1];
        } 
    }
}
