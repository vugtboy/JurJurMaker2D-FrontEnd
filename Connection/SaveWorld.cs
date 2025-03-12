using UnityEngine;
using System.Collections.Generic;
using System;
public class SaveWorld : MonoBehaviour
{
    //deze gaat over alles wat te maken heeft met het opslaan en wijzigen van de wereld
    private List<GetAllObjectsResponseDto> objects;
    public List<WorldObject> objectsInScene;
    public List<WorldObject> existingObjects;
    public List<string> deletedObjectsIds;
    public TemporaryWorldStorer world;

    private List<PostObjectRequestDto> saveObjects;
    private ObjectRepository client;
    public GameObject[] allObjects;
    private WorldRepository worldClient;
    public bool loaded;
    public void Start()
    {
        worldClient = GameObject.Find("APIManager").GetComponent<WorldRepository>();
        world = GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>();
        client = GetComponent<ObjectRepository>();
        GetObjects();
    }

    void Update()
    {
        //als er een object werwijderd word halen we deze weg uit de lijst met objecten in de scene
        for( int i = 0; i < objectsInScene.Count; i++)
        {
            if (objectsInScene[i] == null)
            {
                objectsInScene.Remove(objectsInScene[i]);
            }
        }
    }

    //alle objecten van een bepaalde wereld ophalen (doen we in start)
    public async void GetObjects()
    {
        objects = await client.GetAllObjects(world.worldId);
        foreach(GetAllObjectsResponseDto obj in objects)
        {
            if (obj.prefabID != 16)
            {
                WorldObject Object = Instantiate(allObjects[obj.prefabID], new Vector3(obj.positionX, obj.positionY, 0), Quaternion.Euler(0, 0, obj.rotationZ)).GetComponent<WorldObject>();
                Object.ObjectId = obj.objectId;
                Object.PrefabID = obj.prefabID;
                Object.PositionX = obj.positionX;
                Object.PositionY = obj.positionY;
                Object.RotationZ = obj.rotationZ;
                Object.aditionalIndex = obj.aditionalIndex;
                Object.SetValues();
                existingObjects.Add(Object);
            }
            //de speler anders behandelen want die bestaat altijd al
            else
            {
                WorldObject Object = GameObject.Find("Player").GetComponent<WorldObject>();
                Object.ObjectId = obj.objectId;
                Object.PrefabID = obj.prefabID;
                Object.PositionX = obj.positionX;
                Object.PositionY = obj.positionY;
                Object.RotationZ = obj.rotationZ;
                Object.aditionalIndex = obj.aditionalIndex;
                Object.SetValues();
                existingObjects.Add(Object);
            }
        }
        loaded = true;
    }
    //alle objecten in een wereld opslaan, hier word bepaald of er verwijderd toegevoegd of gewoon opgeslagen moet worden
    public void Save()
    {
        List<WorldObject> delete = new List<WorldObject>();
        foreach (WorldObject obj in objectsInScene)
        {
            //als het object in de wereld bestaat en al eerder opgeslagen/opgehaald is slaan we gewoon op
            if (existingObjects.Contains(obj))
            {
                PostObjectRequestDto request = new PostObjectRequestDto();
                request.objectId = obj.ObjectId;
                request.prefabID = obj.PrefabID;
                request.positionX = obj.PositionX;
                request.positionY = obj.PositionY;
                request.rotationZ = obj.RotationZ;
                request.aditionalIndex = obj.aditionalIndex;
                request.id = world.worldId;
                client.SaveObject(request);
            }
            //anders voegen we het toe aan opgeslagen/opgehaald(existing) objects en maken we een nieuw object aan
            else
            {
                PostObjectRequestDto request = new PostObjectRequestDto();
                obj.ObjectId = Guid.NewGuid().ToString();
                request.objectId = obj.ObjectId;
                request.prefabID = obj.PrefabID;
                request.positionX = obj.PositionX;
                request.positionY = obj.PositionY;
                request.rotationZ = obj.RotationZ;
                request.aditionalIndex = obj.aditionalIndex;
                request.id = world.worldId;
                client.CreateObject(request);
                existingObjects.Add(obj);
            }
        }
        //als het object nou niet in de scene is maar nog wel in de existigobjects dan moet het verwijderd worden
        foreach (WorldObject obj in existingObjects)
        {
            if (!objectsInScene.Contains(obj))
            {
                client.DeleteObject(obj.ObjectId);
                delete.Add(obj);
            }
        }
        //en dan verwijderen uit de existing lijst
        foreach (WorldObject obj in delete)
        {
            existingObjects.Remove(obj);
        }
        //ook moet de wereld zelf worden opgeslagen, de groote, speler, muziek en achtergrond kan namenlijk gewijzigd worden
        PutWorldRequestDto worldrequest = new PutWorldRequestDto();
        worldrequest.userId = world.world.userId;
        worldrequest.id = world.world.id;
        worldrequest.name = world.world.name;
        worldrequest.maxLength = world.world.maxLength;
        worldrequest.maxHeigth = world.world.maxHeigth;
        worldrequest.player = world.world.player;
        worldrequest.music = world.world.music;
        worldrequest.background = world.world.background;
        worldClient.SaveWorld(worldrequest);
    }
}
