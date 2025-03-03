using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed;
    public int Length;
    public int Heigth;
    public float offsetHeigth;
    public float offsetLength;
    public MapSize mapSize;

    public float smoothTime = 0.25f;
    public Vector3 Velocity = Vector3.zero;
    public Transform target;
    void Start()
    {
        player = GameObject.Find("CameraTarget").transform;
    }
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), ref Velocity, smoothTime);

        Length = mapSize.maxLength;
        Heigth = mapSize.maxHeigth;
        if (transform.position.x < offsetLength)
        {
            transform.position = new Vector3(offsetLength, transform.position.y, -10);
        }
        if (transform.position.x > Length - offsetLength)
        {
            transform.position = new Vector3(Length - offsetLength, transform.position.y, -10);
        }
        if (transform.position.y < offsetHeigth)
        {
            transform.position = new Vector3(transform.position.x, offsetHeigth, -10);
        }
        if (transform.position.y > Heigth - offsetHeigth)
        {
            transform.position = new Vector3(transform.position.x, Heigth - offsetHeigth, -10);
        }
    }
}
