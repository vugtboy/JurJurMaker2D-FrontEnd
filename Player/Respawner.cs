using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class Respawner : MonoBehaviour
{
    public Vector3 respawnPoint;
    public GameObject Player;
    public GameObject PlayerObject;
    public PlayerProjectiles projectiles;
    public bool checkPoint;
    public GameModeManager modeManager;
    public Animator UIResetAnimator;
    public int WaitForUI;
    public int WaitForRespawn;
    public bool previous;
    public bool ability;
    void Start()
    {
        previous = true;
        modeManager = GameObject.Find("GameMode").GetComponent<GameModeManager>();
        Player = GameObject.Find("Player");
        PlayerObject = GameObject.Find("PlayerObject");
        projectiles = PlayerObject.GetComponent<PlayerProjectiles>();
    }

    public void Respawn()
    {
        UIResetAnimator.ResetTrigger("Break");
        StartCoroutine("Reset");
        if (!checkPoint)
        {
            projectiles.hasAbility = false;
            Destroy(projectiles.PowerTrumpet);
        }
    }

    public void ResetCheckpoint()
    {
        StopCoroutine("Reset");
        UIResetAnimator.SetTrigger("Break");
        checkPoint = false;
        respawnPoint = Player.transform.position;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(WaitForUI);
        UIResetAnimator.SetTrigger("Respawn");
        yield return new WaitForSeconds(WaitForRespawn);
        modeManager.Play = false;
        yield return new WaitForSeconds(0.1f);
        modeManager.Play = true;
        PlayerObject.gameObject.transform.position = respawnPoint;
        Player.SetActive(true);
        if(ability && checkPoint)
        {
            projectiles.hasAbility = true;
        }
    }
}
