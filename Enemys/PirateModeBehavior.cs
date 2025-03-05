using UnityEngine;

public class PirateModeBehavior : MonoBehaviour
{
    public GameModeManager ModeManager;

    public GameObject EditObject;
    public GameObject PlayObject;
    public EnemyPatrol enemy;
    private PirateDeath death;
    public bool previousState;
    void Start()
    {
        death = GetComponentInChildren<PirateDeath>();
        enemy = GetComponentInChildren<EnemyPatrol>();
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        previousState = ModeManager.Play;
        if (!ModeManager.Play)
        {
            enemy.anim.SetBool("Falling", false);
            enemy.anim.SetBool("Right", true);
            enemy.direction = -1;
            EditObject.SetActive(true);
            PlayObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            PlayObject.SetActive(false);
        }
    }
    void Update()
    {
        if (ModeManager.Play != previousState)
        {
            if (!ModeManager.Play)
            {
                if (death.deadme != null)
                {
                    Destroy(death.deadme);
                }
                enemy.anim.SetBool("Falling", false);
                enemy.anim.SetBool("Right", true);
                enemy.direction = -1;
                EditObject.SetActive(true);
                PlayObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                PlayObject.SetActive(false);
            }
            else
            {
                PlayObject.SetActive(true);
                EditObject.SetActive(false);
            }
            previousState = ModeManager.Play;
        }
    }
}
