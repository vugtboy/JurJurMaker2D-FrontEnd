using UnityEngine;

public class EditCamera : MonoBehaviour
{
    public int Length;
    public int Heigth;
    public float offsetHeigth;
    public float offsetLength;
    public MapSize mapSize;
    public float speed;
    public float activeSpeedx;
    public float activeSpeedy;
    public float speeder;
    void Update()
    {
        Length = mapSize.maxLength;
        Heigth = mapSize.maxHeigth;
        if(transform.position.x < offsetLength)
        {
            transform.position = new Vector3(offsetLength, transform.position.y, -10);
            activeSpeedx = 0;
        }
        if(transform.position.x > Length - offsetLength)
        {
            transform.position = new Vector3(Length - offsetLength, transform.position.y, -10);
            activeSpeedx = 0;
        }
        if (transform.position.y < offsetHeigth)
        {
            transform.position = new Vector3(transform.position.x, offsetHeigth, -10);
            activeSpeedy = 0;
        }
        if (transform.position.y > Heigth - offsetHeigth)
        {
            transform.position = new Vector3(transform.position.x, Heigth - offsetHeigth, -10);
            activeSpeedy = 0;
        }

        float ofsetx = activeSpeedx * Time.deltaTime;
        float ofsety = activeSpeedy * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + ofsety, -10);
            activeSpeedy += speeder * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - ofsety, -10);
            activeSpeedy += speeder * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - ofsetx, transform.position.y, -10);
            activeSpeedx += speeder * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + ofsetx, transform.position.y, -10);
            activeSpeedx += speeder * Time.deltaTime;
        }
        if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            activeSpeedx = speed;
            activeSpeedy = speed;
        }
    }
}
