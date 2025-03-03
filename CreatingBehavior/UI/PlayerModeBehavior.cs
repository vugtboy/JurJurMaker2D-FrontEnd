using UnityEngine;

public class PlayerModeBehavior : MonoBehaviour
{
    public GameModeManager ModeManager;

    public GameObject EditObject;
    public GameObject PlayObject;
    public PlayerProjectiles player;
    public PlayerBehavior playerBehavior;

    void Start()
    {
        player = GetComponentInChildren<PlayerProjectiles>();
        playerBehavior = GetComponentInChildren<PlayerBehavior>();
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
    }
    void Update()
    {
        if (!ModeManager.Play)
        {
            Destroy(playerBehavior.myDeathBody);
            player.hasAbility = false;
            playerBehavior.actualSpeed = 0;
            playerBehavior.direction = 1;
            EditObject.SetActive(true);
            PlayObject.transform.localScale = new Vector3(0.8666667f, 0.8666667f, 0);
            PlayObject.transform.parent.gameObject.SetActive(true);
            PlayObject.transform.position = EditObject.transform.position;
            playerBehavior.holdingBox = false;
            if (playerBehavior.box != null)
            {
                playerBehavior.box.Trow(playerBehavior.direction);
                playerBehavior.box = null;
            }
            playerBehavior.anim.SetBool("HasBox", false);           
            PlayObject.SetActive(false);
        }
        else
        {
            PlayObject.SetActive(true);      
            EditObject.SetActive(false);
        }
    }
}
