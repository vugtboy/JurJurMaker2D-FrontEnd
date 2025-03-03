using UnityEngine;

public class PlayerOutOfBounds : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;

    public Vector3 defaultPosition;
    public MapSize mapSize;

    void Start()
    {
        mapSize = GameObject.Find("MapSizeEditor").GetComponent<MapSize>();
    }

    void Update()
    {
        if(point1.transform.position.x < -0.1f || point1.transform.position.x > mapSize.maxLength || point2.transform.position.x < -0.1f || point2.transform.position.x > mapSize.maxLength || point1.transform.position.y < -0.1f || point1.transform.position.y > mapSize.maxHeigth || point2.transform.position.y < -0.1f || point2.transform.position.y > mapSize.maxHeigth)
        {
            transform.position = defaultPosition;
        }
    }
}