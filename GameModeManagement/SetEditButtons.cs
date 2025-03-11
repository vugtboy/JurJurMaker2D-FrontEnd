using UnityEngine;
using System.Collections;
public class SetEditButtons : MonoBehaviour
{
    public GameObject editMode1;
    public GameObject editMode2;
    public GameObject exit;
    void Start()
    {
        if(GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>().playModeOnly)
        {
            editMode1.SetActive(false);
            Destroy(editMode2);
            StartCoroutine(DontBreakTheExit());
        }
        else
        {
            exit.SetActive(false);
        }
    }

    IEnumerator DontBreakTheExit()
    {
        yield return new WaitForSeconds(3f);
        exit.SetActive(true);
    }
}
