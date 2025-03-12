using UnityEngine;
using System.Collections;
public class TunrOffOnEnabled : MonoBehaviour
{
    //een scriptje om meldingen automatisch weg te laten gaan na een bepaalde hoeveelheid tijd
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
