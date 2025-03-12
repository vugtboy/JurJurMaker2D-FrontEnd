using UnityEngine;
using System.Collections.Generic;
using System;
public class VisualObjectList : MonoBehaviour
{
    // in de ui is een scrol dingtje bovenin, dit zet hem op het geselecteerde blok, volgens de placer die het blok ook toont
    public GameObject[] Objects;
    public int Selected;
    public Transform Selector;

    void Update()
    {
        Selector.position = Objects[Selected].transform.position;
    }
}
