using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class World : MonoBehaviour
{
    public GetWorldResponseDto world;
    public string userId;
    public string id;
    public string worldName;
    public int maxLength;
    public int maxHeigth;
    public int player;
    public int music;
    public int background;

    public Image backgroundDisplay;
    public Sprite[] backgrounds;

    public TMP_Text worldNameText;
    public WorldLoader loader;
    private TemporaryWorldStorer worldStorer;
    void Start()
    {
        loader = GameObject.Find("WorldLoader").GetComponent<WorldLoader>();
        worldStorer = GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>();
    }
    void Update()
    {
        
        worldNameText.text = worldName;
        backgroundDisplay.sprite = backgrounds[background];
    }

    public void Delete()
    {
        loader.DeleteWorld(id);
        Destroy(this.gameObject);
    }

    public void Play()
    {
        worldStorer.OpenWorld(id, world, true);
    }

    public void Edit()
    {
        worldStorer.OpenWorld(id, world, false);
    }
}
