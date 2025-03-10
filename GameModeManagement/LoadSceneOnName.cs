using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnName : MonoBehaviour
{
    public string sceneName;

    public void Click()
    {
        SceneManager.LoadScene(sceneName);
    }
}
