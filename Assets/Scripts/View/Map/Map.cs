using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, IMouseInputHandler, IUpdateable
{
    [SerializeField]
    CharacterCollection _agentCollection;
    [SerializeField]
    BuildingCollection _buildingCollection;
    [SerializeField]
    Transform _spawnedObjectsRoot;

    TileMapper _tilemapper;
    Dictionary<string, Building> _buildings = new Dictionary<string, Building>();
    Dictionary<string, Agent> _agents = new Dictionary<string, Agent>();

    Queue<(int, int, string)> _cheatSetTileQueue = new Queue<(int, int, string)>();
    bool _isBuilt=false;

    public void SetTile(Vector3 position, string type)
    {
        var tile = _tilemapper.GetTileFromPosition(position);
        _cheatSetTileQueue.Enqueue((tile.x, tile.y, type));
    }

    private void Awake()
    {
        _tilemapper = GetComponent<TileMapper>();
    }

    /// <summary>
    /// Update with new model data for per-frame updates
    /// </summary>
    /// <param name="model"></param>
    public void UpdateFromModel(IGameModel model)
    {
        if(!_isBuilt)
        {
            FullRebuild(model);
        }

        foreach (var b in model.Map.Buildings)
        {
            var building = GetBuildingFromModel(b);
            building.UpdateModel(b, model);
        }

        foreach(var a in model.Characters)
        {
            UpdateAgent(a);
        }

        while (_cheatSetTileQueue.Count > 0)
        {
            var (x,y,type) = _cheatSetTileQueue.Dequeue();
            model.Cheats.SetTile(x, y, type);
            _tilemapper.SetTile(x, y, model.Cheats.GameModel.Map);
        }
    }

    void UpdateAgent(ICharacterModel model)
    {
        var agent = GetAgentFromModel(model);
        var position = _tilemapper.ModelToWorld(model.WorldPosition);
        agent.SetPosition(position);
        agent.gameObject.SetActive(model.IsVisibleOnMap);
    }

    void FullRebuild(IGameModel model)
    {
        foreach (var b in model.Map.Buildings)
        {
            Building building = GetBuildingFromModel(b);
            PositionBuilding(building, b.Position);
        }

        foreach (var a in model.Characters)
        {
            Agent agent = GetAgentFromModel(a);
            // more spawn agent stuff
        }

        _tilemapper.BuildTilemap(model.Map);

        _isBuilt = true;
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
        var prefab = Instantiate(_buildingCollection.GetPrefab(name));
        SetSpawnedParent(prefab.transform);
        var building = prefab.GetComponent<Building>();
        _buildings.Add(name, building);
        return building;
    }

    void PositionBuilding(Building building, Vector2Int gridPosition)
    {
        building.transform.position = _tilemapper.GetWorldCenterOftile((Vector3Int)gridPosition);
    }

    Agent GetAgentFromModel(ICharacterModel model)
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
        var prefab = Instantiate(_agentCollection.GetData(name).MapPrefab);
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
