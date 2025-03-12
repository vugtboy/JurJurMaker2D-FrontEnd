using UnityEngine;

public class BlockColliderFix : MonoBehaviour
{
    //voor elk block in de game de parent van het object instellen als eentje met een composite collider zodat de colliders samengevoegd worden
    //(om te voorkomen dat de speler of dozen blijven hangen aan de rand van de collider)
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
