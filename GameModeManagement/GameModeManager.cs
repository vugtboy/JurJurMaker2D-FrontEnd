using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Collections;
public class GameModeManager : MonoBehaviour
{
    public bool Play;
    public GameObject placer;
    public Respawner respawner;
    public GameObject Player;
    public GameObject menu;
    public GameObject editButton;
    public GameObject PlayCamera;
    public GameObject EditCamera;
    public CoinCounter counter;
    public List<GameObject> PlayObjects;
    private ObjectTypes objects;
    private GameObject MapSizeEditing;
    private GameObject Warning;
    private GameObject CostumizationButtons;
    private GameObject Grid;
    private GameObject PlayerSetButtons;
    private GameObject MusicEdit;
    private GameObject BackgroundMenu;
    private GameObject MusicMenu;
    private Animator tomateWarning;
    private Animator dupeWarning;
    public bool playOnly;
    private TemporaryWorldStorer world;
    private SaveWorld saver;
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    public void Start()
    {
        saver = GameObject.Find("WorldSavage").GetComponent<SaveWorld>();
        Player = GameObject.Find("PlayerObject");
        counter = Player.GetComponent<CoinCounter>();
        respawner = GameObject.Find("Respawner").GetComponent<Respawner>();
        placer = GameObject.Find("#Placer#");
        objects = placer.GetComponent<ObjectTypes>();
        MapSizeEditing = GameObject.Find("MapSizeEditing");
        Warning = GameObject.Find("Warning");
        CostumizationButtons = GameObject.Find("CostumizationButtons");
        Grid = GameObject.Find("Grid");
        PlayerSetButtons = GameObject.Find("#PlayerSetButtons");
        MusicEdit = GameObject.Find("MusicEdit");
        BackgroundMenu = GameObject.Find("Background Menu");
        MusicMenu = GameObject.Find("MusicMenu");
        dupeWarning = GameObject.Find("#Notefication").GetComponent<Animator>();
        tomateWarning = GameObject.Find("#Notefication Tomate").GetComponent<Animator>();
        world = GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>();
        if (world.playModeOnly)
        {
            playOnly = true;
        }        
    }
    public void ToPlayModeOnStart()
    {
        counter.Counter = respawner.Coins;
        EditCamera.SetActive(false);
        PlayCamera.SetActive(true);
        respawner.respawnPoint = Player.transform.position;
        Play = true;
        //sorry voor deze, ik zag geen andere weg omdat tomaten moeten bestaan, eerst deed ik deze acties met de button zelf, maar ik wil
        //een waarschuwing geven als je op play drukt en dat kan alleen zo |=.
        placer.SetActive(false);
        menu.SetActive(false);
        editButton.SetActive(true);
        MapSizeEditing.SetActive(false);
        Warning.SetActive(false);
        CostumizationButtons.SetActive(true);
        Grid.SetActive(false);
        PlayerSetButtons.SetActive(false);
        MusicEdit.SetActive(false);
        BackgroundMenu.SetActive(false);
        MusicMenu.SetActive(false);
        tomateWarning.SetBool("Note", false);
        dupeWarning.SetBool("Note", false);
    }

    public void ToPlayMode()
    {
        if(HasTomate())
        {
            counter.Counter = respawner.Coins;
            EditCamera.SetActive(false);
            PlayCamera.SetActive(true);
            respawner.respawnPoint = Player.transform.position;
            Play = true;
            //sorry voor deze, ik zag geen andere weg omdat tomaten moeten bestaan, eerst deed ik deze acties met de button zelf, maar ik wil
            //een waarschuwing geven als je op play drukt en dat kan alleen zo |=.
            placer.SetActive(false);
            menu.SetActive(false);
            editButton.SetActive(true);
            MapSizeEditing.SetActive(false);
            Warning.SetActive(false);
            CostumizationButtons.SetActive(true);
            Grid.SetActive(false);
            PlayerSetButtons.SetActive(false);
            MusicEdit.SetActive(false);
            BackgroundMenu.SetActive(false);
            MusicMenu.SetActive(false);
            tomateWarning.SetBool("Note", false);
            dupeWarning.SetBool("Note", false);
        }
        else
        {
            tomateWarning.SetBool("Note", true);
        }
    }

    public void ToEdit()
    { 
        PlayCamera.SetActive(false);
        EditCamera.SetActive(true);
        int xPos = 960, yPos = 540;
        SetCursorPos(xPos, yPos);
        Play = false;
        StartCoroutine(ToEditMode());
    }

    IEnumerator ToEditMode()
    {
        yield return new WaitForSeconds(0.1f);
        placer.SetActive(true);
        menu.SetActive(true);
        editButton.SetActive(false);
    }

    void Update()
    {
        if(playOnly && saver.loaded)
        {
            ToPlayModeOnStart();
            playOnly = false;
        }
        if(!Play)
        {
            foreach (GameObject Object in PlayObjects)
            {
                Destroy(Object);
            }
        }
    }

    bool HasTomate()
    {
        foreach(GameObject obj in objects.placedObjects)
        {
            if(obj.CompareTag("Ending"))
            {
                return true;
            }
        }
        return false;
    }


}
