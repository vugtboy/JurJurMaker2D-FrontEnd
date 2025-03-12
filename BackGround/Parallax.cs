using UnityEngine;
using System;
public class Parallax : MonoBehaviour
{
    //voor paralax in de achtergrond omdat ik geen 3d camera gebruik, want die doet vreemd met de cursor van de muis positie bepalen
    private Vector2 startPos;
    private float length;
    public Camera[] cams;

    public float ParallaxAmountX;
    public float ParallaxAmountY;
    public bool loop = true;

    private SpriteRenderer SpriteRenderer;
    private Bounds spriteBounds;
    public Vector2 camStartPos;

    private GameModeManager modeManager;
    void Start()
    {
        modeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        spriteBounds = SpriteRenderer.localBounds;

        startPos = transform.position;
        length = spriteBounds.size.x;
    }
    //de achtergrond laten meebewegen met de camera dus om het effect te geven dat deze verder weg is
    void Update()
    {
        int current = 0;
        if(modeManager.Play)
        {
            current = 1;
        }
        float distanceX = (cams[current].transform.position.x - camStartPos.x) * ParallaxAmountX;
        float distanceY = (cams[current].transform.position.y - camStartPos.y) * ParallaxAmountY;

        transform.position = new Vector2(startPos.x + distanceX, startPos.y + distanceY);

        float movementX = (cams[current].transform.position.x - camStartPos.x) * (1 - ParallaxAmountX);

        if (loop)
        {
            if (movementX > startPos.x + length)
            {
                startPos.x += length;
            }
            else if (movementX < startPos.x - length)
            {
                startPos.x -= length;
            }
        }
    }
}
