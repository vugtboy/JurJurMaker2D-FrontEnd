using UnityEngine;

public class Saw : MonoBehaviour
{
    //de zaag in playmode laten bewegen tussen 2 points
    public Transform[] points;
    public int currentPos;
    public float speed;
    public GameModeManager manager;
    void Start()
    {
        manager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
    }

    void Update()
    {
        if (transform.position == points[currentPos].position)
        {
            if (currentPos < points.Length -1)
            {
                currentPos++;
            }
            else
            {
                currentPos = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[currentPos].position, speed * Time.deltaTime);       
    }
}
