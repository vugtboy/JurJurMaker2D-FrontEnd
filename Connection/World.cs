using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class World : MonoBehaviour
{
    //de wereld in het menu, om de juiste dingen te tonen, zoals de achtergrond bij het plaatje, en de naam
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
    //als je op de deleteknop drukt van de wereld moet de wereld gedelet worden, dan gaat de worldloader, die weer contact maakt met de repository de wereld verwijderen
    public void Delete()
    {
        loader.DeleteWorld(id);
        Destroy(this.gameObject);
    }

    //als je op play drukt moet de wereld opgestart worden in playmode, dit zodat je alleen kunt spelen en niet editen
    public void Play()
    {
        worldStorer.OpenWorld(id, world, true);
    }
    //anders druk je op edit, en word de wereld gewoon opgestart in editmode
    public void Edit()
    {
        worldStorer.OpenWorld(id, world, false);
    }
}
