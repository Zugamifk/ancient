using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    Transform _spawnedObjectsRoot;

    PrefabCollectionSet _prefabCollections;

    TileMapper _tilemapper;
    Dictionary<string, Building> _buildings = new Dictionary<string, Building>();
    Dictionary<string, Agent> _agents = new Dictionary<string, Agent>();
    ICheatController _cheatController;

    public void SetCheatController(ICheatController controller)
    {
        _cheatController = controller;
    }

    public void SetPrefabCollections(PrefabCollectionSet prefabCollections)
    {
        _prefabCollections = prefabCollections;
        _tilemapper.SetPrefabCollections(prefabCollections);
    }

    public void SetTile(Vector3 position, string type)
    {
        _cheatController.SetTile(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), type);
        _tilemapper.SetTile(Mathf.FloorToInt(position.x),Mathf.FloorToInt(position.y), type, _cheatController.GameModel.Map);
    }

    private void Awake()
    {
        _tilemapper = GetComponent<TileMapper>();
    }

    /// <summary>
    /// Fully build map 
    /// </summary>
    /// <param name="model"></param>
    public void FullRebuild(IGameModel model)
    {
        foreach(var b in model.Map.Buildings)
        {
            Building building = GetBuildingFromModel(b);
            PositionBuilding(building, b.Position);
        }

        foreach (var a in model.Agents)
        {
            Agent agent = GetAgentFromModel(a);
            // more spawn agent stuff
        }

        _tilemapper.BuildTilemap(model.Map);
    }

    /// <summary>
    /// Update with new model data for per-frame updates
    /// </summary>
    /// <param name="model"></param>
    public void FrameUpdate(IGameModel model)
    {
        foreach (var b in model.Map.Buildings)
        {
            var building = GetBuildingFromModel(b);
            building.FrameUpdate(model);
        }

        foreach(var a in model.Agents)
        {
            var agent = GetAgentFromModel(a);
            agent.FrameUpdate(a);
        }
    }

    Building GetBuildingFromModel(IBuildingModel model)
    {
        Building building;
        if (!_buildings.TryGetValue(model.Name, out building))
        {
            building = SpawnBuilding(model.Name);
        }
        return building;
    }

    Building SpawnBuilding(string name)
    {
        var prefab = Instantiate(_prefabCollections.BuildingCollection.GetPrefab(name));
        SetSpawnedParent(prefab.transform);
        var building = prefab.GetComponent<Building>();
        _buildings.Add(name, building);
        return building;
    }

    void PositionBuilding(Building building, Vector2Int gridPosition)
    {
        var position = new Vector3(gridPosition.x, gridPosition.y, 0);
        building.transform.position = position;
    }

    Agent GetAgentFromModel(IAgentModel model)
    {
        Agent agent;
        if (!_agents.TryGetValue(model.Name, out agent))
        {
            agent = SpawnAgent(model.Name);
        }
        return agent;
    }

    Agent SpawnAgent(string name)
    {
        var prefab = Instantiate(_prefabCollections.AgentCollection.GetPrefab(name));
        SetSpawnedParent(prefab.transform);
        var agent = prefab.GetComponent<Agent>();
        _agents.Add(name, agent);
        return agent;
    }

    void SetSpawnedParent(Transform child)
    {
        child.SetParent(_spawnedObjectsRoot);
        SetLayer(child, _spawnedObjectsRoot.gameObject.layer);
    }

    void SetLayer(Transform tf, int layer)
    {
        tf.gameObject.layer = layer;
        foreach(Transform child in tf)
        {
            SetLayer(child, layer);
        }
    }

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        return new MapMouseInput(state, this);
    }
}
