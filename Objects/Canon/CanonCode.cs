using UnityEngine;
using System.Collections.Generic;
using System;
public class CanonCode : MonoBehaviour
{
    //op animatiekey een kanonskogel inspawnen
    public GameObject CanonBowl;
    public Transform CanonBowlSpawnpoint;

    public void Create()
    {
        Instantiate(CanonBowl, CanonBowlSpawnpoint.position, transform.rotation);
    }

}
