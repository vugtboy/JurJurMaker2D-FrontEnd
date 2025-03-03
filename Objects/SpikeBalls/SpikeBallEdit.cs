using UnityEngine;

public class SpikeBallEdit : MonoBehaviour
{
    public int phase;
    public GameObject indicator;
    public float isMoving;
    public bool selected;

    void Update()
    {
        if(selected)
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
            if (phase < 3)
            {
                phase++;
                indicator.transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 90);
                indicator.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                transform.localScale = new Vector3(1, 1, 1);
                transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 90);
            }
            else if (phase < 7)
            {
                phase++;
                indicator.transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 90);
                indicator.transform.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
                transform.localScale = new Vector3(-1, 1, 1);
                transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 90);
            }
            else
            {
                phase = 0;
                indicator.transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 90);
                indicator.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                transform.localScale = new Vector3(1, 1, 1);
                transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + 90);
            }
        }
        selected = false;
    }
}
