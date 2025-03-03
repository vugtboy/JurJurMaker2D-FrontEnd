using UnityEngine;
using System;
public class Parallax : MonoBehaviour
{
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
