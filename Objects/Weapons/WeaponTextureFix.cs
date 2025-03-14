using UnityEngine;
using UnityEngine.UI;
public class WeaponTextureFix : MonoBehaviour
{
    //texture van het wapen per speler aanpassen omdat JurJur een bijl heeft en Stumpy een zwaard en Anton een piratenZwaard
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
