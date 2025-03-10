using UnityEngine;
using System;
public class WorldObject : MonoBehaviour
{
    public string ObjectId;
    public string Id;
    public int PrefabID;
    public int PositionX;
    public int PositionY;
    public int RotationZ;
    public int aditionalIndex;

    private CanonRotations canon;
    private FlameTrowerEditModeBehavior flametrow;
    private SpikeBallEdit spike;
    private SawSwitchmode saw;
    private SaveWorld saver;
    private ObjectTypes placer;
    void Start()
    {
        saver = GameObject.Find("WorldSavage").GetComponent<SaveWorld>();
        saver.objectsInScene.Add(this);
        if (PrefabID == 7)
        {
            canon = GetComponentInChildren<CanonRotations>();
        }
        else if (PrefabID == 10)
        {
            flametrow = GetComponentInChildren<FlameTrowerEditModeBehavior>();
        }
        else if (PrefabID == 12)
        {
            saw = GetComponentInChildren<SawSwitchmode>();
        }
        else if (PrefabID == 13)
        {
            spike = GetComponentInChildren<SpikeBallEdit>();
        }
        else if (PrefabID == 16)
        {
            transform.position = new Vector3(PositionX, PositionY, 0);
        }
    }

    public void SetValues()
    {
        placer = GameObject.Find("#Placer#").GetComponent<ObjectTypes>();
        if(PrefabID != 8 && PrefabID != 15 && PrefabID != 16)
        {
            placer.placedObjects.Add(this.gameObject);
        }
        if (PrefabID == 7)
        {
            canon = GetComponentInChildren<CanonRotations>();
            canon.SetPhase(aditionalIndex);
        }
        else if (PrefabID == 10)
        {
            flametrow = GetComponentInChildren<FlameTrowerEditModeBehavior>();
            flametrow.SetPhase(aditionalIndex);
        }
        else if (PrefabID == 12)
        {
            saw = GetComponentInChildren<SawSwitchmode>();
            saw.SetPhase(aditionalIndex);
        }
        else if (PrefabID == 13)
        {
            spike = GetComponentInChildren<SpikeBallEdit>();
            spike.SetPhase(aditionalIndex);
        }
        else if(PrefabID == 16)
        {
            transform.position = new Vector3(PositionX, PositionY, 0);
        }
    }

    public void Remove()
    {
        if(saver.objectsInScene.Contains(this))
        saver.objectsInScene.Remove(this);

    }
    void Update()
    {
        PositionX = Convert.ToInt32(transform.position.x);
        PositionY = Convert.ToInt32(transform.position.y);
        RotationZ = Convert.ToInt32(transform.rotation.z);
        if(PrefabID == 7)
        {
            aditionalIndex = canon.phase;
        }
        else if (PrefabID == 10)
        {
            aditionalIndex = flametrow.index;
        }
        else if (PrefabID == 12)
        {
            aditionalIndex = saw.index;
        }
        else if (PrefabID == 13)
        {
            aditionalIndex = spike.phase;
        }
    }
}
