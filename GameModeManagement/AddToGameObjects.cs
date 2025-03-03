using UnityEngine;

public class AddToGameObjects : MonoBehaviour
{
    private GameModeManager modeManager;
    void Start()
    {
        modeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        modeManager.PlayObjects.Add(this.gameObject);
    }

    void OnDestroy()
    {
        Debug.Log("OhJaJoh");
    }
}
