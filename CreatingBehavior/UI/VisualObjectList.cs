using UnityEngine;
using System.Collections.Generic;
using System;
public class VisualObjectList : MonoBehaviour
{
    public GameObject[] Objects;
    public int Selected;
    public Transform Selector;

    void Update()
    {
        Selector.position = Objects[Selected].transform.position;
    }
}
