using UnityEngine;
using UnityEngine.SceneManagement;
public class TemporaryWorldStorer : MonoBehaviour
{
    //wereld tijdelijk opslaang zodat we de wereld op de juiste manier kunnen generen 
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
    //hier worden de waarden indesteld, dat gebeurt in het menu. als je alleen op play drukt moet de wereld anders opgestart worden.
    //het wereld id en alle waarden van de wereld zelf worden opgeslagen, zodat die gebruikt kunnen worden in de wereld om de groote etc in te stellen in start
    //en het Id voor als je iets aan de wereld wijzigt wat opgeslagen moet worden
    public void OpenWorld(string worldId, GetWorldResponseDto world, bool playMode)
    {
        playModeOnly = playMode;
        this.worldId = worldId;
        this.world = world;
        SceneManager.LoadScene("Game");       
    }
}
