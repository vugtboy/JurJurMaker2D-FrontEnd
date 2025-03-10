using UnityEngine;

public class FlameTrowerEditModeBehavior : MonoBehaviour
{
    public bool flame;
    public SpriteRenderer indicator;
    public Sprite[] textures;
    public bool selected;
    public float isMoving;
    public int index;

    public void SetPhase(int index)
    {
        this.index = index;
        transform.parent.eulerAngles = new Vector3(0, 0, index / 2 * -90);
        if(index == 1 || index == 3 || index == 5 || index == 7)
        {
            flame = true;
            indicator.sprite = textures[1];
        }
        else
        {
            indicator.sprite = textures[0];
        }
        
    }
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
            if (index < 7 && flame)
            {
                index++;
                transform.parent.eulerAngles = new Vector3(0, 0, index/2 * - 90);
                flame = false;
                indicator.sprite = textures[0];
            }
            else if(index < 7 && !flame)
            {
                index++;
                flame = true;
                indicator.sprite = textures[1];
            }
            else if(index == 7)
            {
                index = 0;
                transform.parent.eulerAngles = new Vector3(0, 0, index / 2 * -90);
                flame = false;
                indicator.sprite = textures[0];
            }
        }
        selected = false;
    }
}
