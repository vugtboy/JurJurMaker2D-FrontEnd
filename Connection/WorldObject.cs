using UnityEngine;
using System;
public class WorldObject : MonoBehaviour
{
    //dit is een object binnen de wereld met de waarden
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
    //het object word toegevoegd aan de objectsinscene van de worldsaver, voor sommige uitzonderingen word een script opgehaald waarin het object gewijzigd word,
    //om de index in te stellen, zoals de kant waarop een spikeball draait in combinatie met zijn rotatie
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
    //de waarden worden ingesteld volgens de juiste indexes, ook word de het object, tenzij checkpoint speler of finsh(uitzonderingen wegens 2 hoog) toegevoegd aan de geplaatste object volgens de placer
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
    //als het object gedelete word het object verwijderen uit de in scene objecten van de objectsaver
    public void Remove()
    {
        if(saver.objectsInScene.Contains(this))
        saver.objectsInScene.Remove(this);

    }
    //de waarden van dit object bijhouden voor als het opgeslagen moet worden
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
