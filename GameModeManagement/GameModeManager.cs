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
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    public void Start()
    {
        
        Player = GameObject.Find("PlayerObject");
        counter = Player.GetComponent<CoinCounter>();
        respawner = GameObject.Find("Respawner").GetComponent<Respawner>();
        placer = GameObject.Find("#Placer#");
    }

    public void ToPlayMode()
    {
        counter.Counter = respawner.Coins;
        EditCamera.SetActive(false);
        PlayCamera.SetActive(true);
        respawner.respawnPoint = Player.transform.position;
        Play = true;
        placer.SetActive(false);
        menu.SetActive(false);
        editButton.SetActive(true);
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
        if(!Play)
        {
            foreach (GameObject Object in PlayObjects)
            {
                Destroy(Object);
            }
        }
    }
}
