using UnityEngine;
using System.Collections.Generic;
using System;
public class CanonCode : MonoBehaviour
{
    public GameObject CanonBowl;
    public Transform CanonBowlSpawnpoint;
    private GameModeManager modeManager;
    void Start()
    {
        modeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
    }

    public void Create()
    {
        Instantiate(CanonBowl, CanonBowlSpawnpoint.position, transform.rotation);
    }

}
