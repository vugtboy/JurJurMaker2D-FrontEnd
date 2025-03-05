using UnityEngine;
using UnityEngine.UI;
public class PlayerSelector : MonoBehaviour
{
    public int selectedPlayer;
    public Sprite[] weapons;
    public Sprite[] theBoys;
    public SpriteRenderer PlayerPlay;
    public SpriteRenderer PlayerEdit;
    private Image uiWeapon;
    public Animator PlayerAnim;
    public RuntimeAnimatorController[] Animators;
    private Image uiPlayer;
    private PlayerBehavior player;

    void Start()
    {
        player = GetComponentInChildren<PlayerBehavior>();
        uiWeapon = GameObject.Find("#Weapon").GetComponent<Image>();
    }

    public void SetPlayer(int selectedPlayer)
    {
        this.selectedPlayer = selectedPlayer;
        PlayerEdit.sprite = theBoys[selectedPlayer];
        PlayerPlay.sprite = theBoys[selectedPlayer];
        PlayerAnim.runtimeAnimatorController = Animators[selectedPlayer];
        uiWeapon.sprite = weapons[selectedPlayer];
        player.playerIndex = selectedPlayer;
    }
}
