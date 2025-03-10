using UnityEngine;
using System.Collections;
public class TunrOffOnEnabled : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(TurnOff());
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
