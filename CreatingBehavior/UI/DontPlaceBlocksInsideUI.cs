using UnityEngine;
using UnityEngine.EventSystems;

public class DontPlaceBlocksInsideUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject placer;
    public GameModeManager manager;
    public bool shouldTurnOn;
    public bool inside;
    public ObjectTypes placerObj;
    void Start()
    {
        placer = GameObject.Find("#Placer#");
        manager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
    }
    public void Update()
    {
        if(inside)
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
