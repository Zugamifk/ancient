using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, IMouseInputHandler
{
    PrefabCollectionSet _prefabCollections;

    TileMapper _tilemapper;
    Dictionary<string, Building> _buildings = new Dictionary<string, Building>();
    Dictionary<string, Agent> _agents = new Dictionary<string, Agent>();

    public void SetPrefabCollections(PrefabCollectionSet prefabCollections)
    {
        _prefabCollections = prefabCollections;
        _tilemapper.SetPrefabCollections(prefabCollections);
    }

    public void SetTile(Vector3 position, string type)
    {
        _tilemapper.SetTile(position, type);
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

        _tilemapper.Clear();
        foreach(var edge in model.Map.CityGraph.EdgePairs)
        {
            var start = GetBuildingFromModel((IBuildingModel)edge.Item1);
            var end = GetBuildingFromModel((IBuildingModel)edge.Item2);
            ConnectBuildings(start, end);
        }
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
        var prefab = Instantiate(_prefabCollections.BuildingCollection.NameToBuilding[name]);
        var building = prefab.GetComponent<Building>();
        _buildings.Add(name, building);
        return building;
    }

    void PositionBuilding(Building building, Vector2Int gridPosition)
    {
        var position = new Vector3(gridPosition.x, gridPosition.y, 0);
        building.transform.position = position;
    }

    void ConnectBuildings(Building start, Building end)
    {
        _tilemapper.CreateRoad(start.EntrancePosition, end.EntrancePosition);
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
        var agent = prefab.GetComponent<Agent>();
        _agents.Add(name, agent);
        return agent;
    }

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        return new MapMouseInput(state, this);
    }
}
