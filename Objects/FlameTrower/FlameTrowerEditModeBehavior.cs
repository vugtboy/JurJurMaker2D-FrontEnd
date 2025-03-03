using UnityEngine;

public class FlameTrowerEditModeBehavior : MonoBehaviour
{
    public bool flame;
    public SpriteRenderer indicator;
    public Sprite[] textures;
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
            if (flame)
            {
                transform.parent.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90);
                flame = false;
                indicator.sprite = textures[0];
            }
            else
            {
                flame = true;
                indicator.sprite = textures[1];
            }
        }
        selected = false;
    }
}
