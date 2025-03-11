using UnityEngine;
using System.Collections;
public class TunrOffOnEnabled : MonoBehaviour
{
    public float time;
    void OnEnable()
    {
        StartCoroutine(TurnOff());
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(time + 1f);
        this.gameObject.SetActive(false);
    }
}
