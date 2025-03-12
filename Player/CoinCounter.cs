using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    //gewoon coins tellen als je ze aanraakt als speler en de coin uitzetten zodat je er maar 1 kan pakken
    public int Counter;
    public GameObject CoinCollect;
    private TMP_Text Coins;
    void Start()
    {
        Coins = GameObject.Find("CoinsCol").GetComponent<TMP_Text>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            col.gameObject.SetActive(false);
            Instantiate(CoinCollect, col.transform.position, col.transform.rotation);
            Counter++;
        }
    }

    void Update()
    {
        Coins.text = "Coins Collected: " + Counter.ToString();
    }
}
