using UnityEngine;
using UnityEngine.UI;
public class WeaponTextureFix : MonoBehaviour
{
    public SpriteRenderer[] sp;
    private int index;
    public Sprite[] textures;
    private PlayerSelector Selector;
    void Start()
    {
        Selector = GameObject.Find("Player").GetComponent<PlayerSelector>();
        index = Selector.selectedPlayer;
        foreach (SpriteRenderer spr in sp)
        {
            spr.sprite = textures[index];
        }
    }

    void Update()
    {
        index = Selector.selectedPlayer;
        foreach (SpriteRenderer spr in sp)
        {
            if (spr != null)
            {
                spr.sprite = textures[index];
            }
        }
    }
}
