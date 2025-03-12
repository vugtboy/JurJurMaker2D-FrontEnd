using UnityEngine;
using UnityEngine.EventSystems;

public class DontPlaceBlocksInsideUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //de placer uitzetten als deze zich in het ui bevint, zodat je niet een blok kan plaatsen waneer je op een knop wil drukken
    public GameObject placer;
    public GameModeManager manager;
    public bool shouldTurnOn;
    public bool inside;
    public ObjectTypes placerObj;
    public bool started;
    private SaveWorld saver;
    void Start()
    {
        saver = GameObject.Find("WorldSavage").GetComponent<SaveWorld>();
        placer = GameObject.Find("#Placer#");
        manager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        started = true;
    }
    public void Update()
    {
        if(inside && started && saver.loaded)
        {
            placer.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (placer.activeSelf == true || placer.GetComponent<ObjectTypes>().isMovingBlock)
        {
            shouldTurnOn = true;
        }
        inside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (shouldTurnOn && !manager.Play && !placer.GetComponent<ObjectTypes>().isMovingBlock)
        {
            placer.SetActive(true);
        }
        shouldTurnOn = false;
        inside = false;
    }

    public void Reset()
    {
        inside = false;
        shouldTurnOn = false;
        placer.SetActive(true);
    }
}
