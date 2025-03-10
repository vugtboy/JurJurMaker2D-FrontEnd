using UnityEngine;

public class CanonRotations : MonoBehaviour
{
    public int phase;
    public Transform defaultRotation;
    public bool selected;
    public float isMoving;
    public void SetPhase(int phase)
    {
        this.phase = phase;
        transform.eulerAngles = new Vector3(0, 0, - 45 * phase);
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
        if(isMoving > 0)
        {
            if (phase < 4)
            {
                phase++;
                transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z - 45);
            }
            else
            {
                phase = 0;
                transform.eulerAngles = defaultRotation.eulerAngles;
            }
        }
        selected = false;
    }
}
