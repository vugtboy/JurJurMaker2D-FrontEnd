using UnityEngine;
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class WorldLoader : MonoBehaviour
{
    private WorldRepository client;
    public GameObject world;
    private Transform worldPlacement;
    private string userId;
    public List<GetWorldResponseDto> worlds;
    public List<string> worldNames;
    private Guid worldId;
    private TemporaryWorldStorer worldStorer;
    

    void Start()
    {
        worldPlacement = GameObject.Find("#Grid").transform;
        client = GameObject.Find("APIManager").GetComponent<WorldRepository>();
        worldStorer = GameObject.Find("#WorldTaker").GetComponent<TemporaryWorldStorer>();
        GetWorlds();
    }

    async Task<string> GetUserId()
    {
        return await client.GetUserId();
    }

    async void GetWorlds()
    {
        worlds = await client.GetAllWorlds(await GetUserId());
        if (worlds != null && worlds.Count > 0)
        {
            foreach (GetWorldResponseDto world in worlds)
            {
                GameObject newWorld = Instantiate(this.world, worldPlacement.position, worldPlacement.rotation);
                newWorld.transform.SetParent(worldPlacement);
                World worldData = newWorld.GetComponent<World>();
                worldData.id = world.id;
                worldData.worldName = world.name;
                worldData.maxLength = world.maxLength;
                worldData.maxHeigth = world.maxHeigth;
                worldData.player = world.player;
                worldData.music = world.music;
                worldData.background = world.background;
                worldData.world = world;
                worldNames.Add(worldData.worldName);
            }
        }
    }

    public async void TryToCreateNewWorld(string WorldName, int Heigth, int Length)
    {
        if(!SimalarWorldName(WorldName) && worlds.Count < 5)
        {
            worldId = Guid.NewGuid();
            GetWorldResponseDto world = new GetWorldResponseDto();
            world.id = worldId.ToString();
            world.name = WorldName;
            world.maxLength = Length;
            world.maxHeigth = Heigth;
            world.userId = await GetUserId();
            worlds.Add(world);
            client.CreateNewWorld(WorldName, Heigth, Length, await GetUserId(), worldId);            
            worldStorer.OpenWorld(worldId.ToString(), world, false);            
        }
    }

    public void DeleteWorld(string id)
    {
        client.DeleteWorld(id);
        foreach (var world in worlds)
        {
            if (world.id == id)
            {
                worlds.Remove(world);
                break;
            }
        }
    }

    public bool SimalarWorldName(string input)
    {
        foreach(string worldName in worldNames)
        {
            if(worldName.Trim(' ') == input)
            {
                return true;
            }
        }
        return false;
    }
}
