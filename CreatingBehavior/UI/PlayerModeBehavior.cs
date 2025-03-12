using UnityEngine;

public class PlayerModeBehavior : MonoBehaviour
{
    //de speler is heel ingewikkeld en moet daardoor tussen veel meer wisselen als je switchst tussen play en edit deze klasse ga ik echt niet helemaal uitleggen
    public GameModeManager ModeManager;

    public GameObject EditObject;
    public GameObject PlayObject;
    public PlayerProjectiles player;
    public PlayerBehavior playerBehavior;
    public CoinCounter coinCounter;
    public Respawner respawner;
    public PlayerSelectorButtons playerSelector;
    void Start()
    {
        coinCounter = GameObject.Find("PlayerObject").GetComponent<CoinCounter>();
        player = GetComponentInChildren<PlayerProjectiles>();
        playerBehavior = GetComponentInChildren<PlayerBehavior>();
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        respawner = GameObject.Find("Respawner").GetComponent<Respawner>();
        playerSelector = EditObject.GetComponent<PlayerSelectorButtons>();
    }
    void Update()
    {
        if (!ModeManager.Play)
        {
            coinCounter.Counter = respawner.Coins;
            Destroy(playerBehavior.myDeathBody);
            player.hasAbility = false;
            player.reShoot = 0;
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
            playerSelector.selected = false;
            PlayObject.SetActive(true);      
            EditObject.SetActive(false);
        }
    }
}
