using UnityEngine;

public class SawSwitchmode : MonoBehaviour
{
    //de index van de zaag aanpassen als er op geklikt word, hij kan wisselen tussen naar rechts en links, en naar boven en onder
    public int index;
    public Sprite[] textures;
    public SpriteRenderer sp;
    public GameObject Saw;
    public bool selected;
    public float isMoving;
    public void SetPhase(int index)
    {
        this.index = index;
        if(index == 0)
        {
            Saw.transform.eulerAngles = new Vector3(0, 0, 0);
            sp.sprite = textures[0];
        }
        else if(index == 1)
        {
            Saw.transform.eulerAngles = new Vector3(0, 0, 90);
            sp.sprite = textures[1];
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
            SwitchMode();
        }
        selected = false;
    }

    void SwitchMode()
    {
        if (index == 1)
        {
            index = 0;
            Saw.transform.eulerAngles = new Vector3(0, 0, 0);
            sp.sprite = textures[0];
        }
        else
        {
            index = 1;
            Saw.transform.eulerAngles = new Vector3(0, 0, 90);
            sp.sprite = textures[1];
        } 
    }
}
