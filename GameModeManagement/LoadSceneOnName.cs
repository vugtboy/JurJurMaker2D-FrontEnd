using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnName : MonoBehaviour
{
    //scene laden op ingevoerde scenenaam voor buttons
    public string sceneName;

    public void Click()
    {
        SceneManager.LoadScene(sceneName);
    }
}
