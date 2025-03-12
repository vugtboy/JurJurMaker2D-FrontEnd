using UnityEngine;

public class AddToGameObjects : MonoBehaviour
{
    //voor wapens en kanonskogels, die kapot moeten als we niet in play zitten
    private GameModeManager modeManager;
    void Start()
    {
        modeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        modeManager.PlayObjects.Add(this.gameObject);
    }

    void OnDestroy()
    {
        modeManager.PlayObjects.Remove(this.gameObject);
    }
}
