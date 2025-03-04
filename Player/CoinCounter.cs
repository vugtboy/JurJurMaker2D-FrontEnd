using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
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
