using UnityEngine;

public class BlockColliderFix : MonoBehaviour
{
    public GameModeManager ModeManager;
    public GameObject newParrent;
    public string objectName;

    void Start()
    {
        ModeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        newParrent = GameObject.Find(objectName);
    }

    void Update()
    {
        if(ModeManager.Play == true)
        { 
            transform.parent = newParrent.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
}
