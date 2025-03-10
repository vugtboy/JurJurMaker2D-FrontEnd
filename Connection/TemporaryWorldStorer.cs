using UnityEngine;
using UnityEngine.SceneManagement;
public class TemporaryWorldStorer : MonoBehaviour
{
    public static TemporaryWorldStorer instance { get; private set; }
    public string worldId;
    private WorldLoader loader;
    public GetWorldResponseDto world;
    public bool playModeOnly;

    //zorgen dat we altijd blijven bestaan
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        loader = GameObject.Find("WorldLoader").GetComponent<WorldLoader>();
    }
    public void OpenWorld(string worldId, GetWorldResponseDto world, bool playMode)
    {
        playModeOnly = playMode;
        this.worldId = worldId;
        this.world = world;
        SceneManager.LoadScene("Game");       
    }
}
