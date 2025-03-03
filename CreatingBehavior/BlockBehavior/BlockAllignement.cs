using UnityEngine;

public class BlockAllignement : MonoBehaviour
{
    public bool selected;
    public ObjectTypes Object;
    public string type;
    public Sprite[] textures;
    public SpriteRenderer texture;
    public bool[] positions;
    public GameObject[] checkers;
    public BoxCollider2D col;
    public BoxCollider2D col2;
    public bool isMoving;
    void Start()
    {
        Object = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
    }

    void Update()
    {
        if (isMoving)
        {
            foreach (GameObject checker in checkers)
            {
                checker.SetActive(false);
            }
            col.enabled = false;
            col2.enabled = false;
            texture.sprite = textures[0];
        }
    }

    public void UpdateTexture()
    {
        if(!isMoving)
        {
            int pos = (positions[0] ? 1 : 0) << 3 | (positions[1] ? 1 : 0) << 2 | (positions[2] ? 1 : 0) << 1 | (positions[3] ? 1 : 0);
            switch (pos)
            {
                case 0b0000: // default
                    texture.sprite = textures[0];
                    break;
                case 0b0001: // top only
                    texture.sprite = textures[1];
                    break;
                case 0b0010: // rechts only
                    texture.sprite = textures[6];
                    break;
                case 0b0011: // top rechts
                    texture.sprite = textures[5];
                    break;
                case 0b0100: // bodem only
                    texture.sprite = textures[7];
                    break;
                case 0b0101: // midden met randjes
                    texture.sprite = textures[11];
                    break;
                case 0b0110: // bodem rechts
                    texture.sprite = textures[8];
                    break;
                case 0b0111: // midden rechts
                    texture.sprite = textures[12];
                    break;
                case 0b1000: // links only
                    texture.sprite = textures[2];
                    break;
                case 0b1001: // links boven
                    texture.sprite = textures[3];
                    break;
                case 0b1010: // midden boven
                    texture.sprite = textures[4];
                    break;
                case 0b1011: // midden boven
                    texture.sprite = textures[4];
                    break;
                case 0b1100: // links onder
                    texture.sprite = textures[9];
                    break;
                case 0b1101: // midden links
                    texture.sprite = textures[13];
                    break;
                case 0b1110: // midden bodem
                    texture.sprite = textures[14];
                    break;
                case 0b1111: // midden
                    texture.sprite = textures[10];
                    break;
            }
        }       
    }

    void OnMouseDown()
    {
        selected = true;
    }

    void OnMouseUp()
    {
        selected = false;
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButton(1))
        {
            Object.placedObjects.Remove(this.gameObject);
            Destroy(this.gameObject);
            Destroy(this);
        }
    }

    public void Fix()
    {
        foreach (GameObject checker in checkers)
        {
            checker.SetActive(true);
        }
        col.enabled = true;
        col2.enabled = true;
    }
}
