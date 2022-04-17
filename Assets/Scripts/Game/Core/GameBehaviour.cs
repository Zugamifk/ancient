using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField]
    BuildingCollection _buildingCollection;
    [SerializeField]
    AgentCollection _agentCollection;
    [SerializeField]
    NarrativeCollection _narrativeCollection;
    [SerializeField]
    TileDataCollection _tileDataCollection;
    [SerializeField]
    MapData _mapData;
    [SerializeField]
    Map _map;

    GameController _controller;
    PrefabCollectionSet _prefabCollections;

    private void Awake()
    {
        _prefabCollections = new PrefabCollectionSet()
        {
            BuildingCollection = _buildingCollection,
            AgentCollection = _agentCollection,
            TileBuilder = _tileDataCollection
        };
    }

    private void Start()
    {
        // Create main controllers
        _controller = new GameController(_agentCollection, _tileDataCollection, _mapData, _narrativeCollection);

        // Init scene objects
        _map.SetPrefabCollections(_prefabCollections);
        _map.SetCheatController(_controller);

        // Start game
        DemoInit();
    }

    private void Update()
    {
        _controller.Frameupdate(Time.deltaTime);
        _map.FrameUpdate(_controller.Model);
    }

    void DemoInit()
    {
        var init = _controller as IGameInitializer;
        init.AddBuilding(Names.Buildings.Manor, Vector2Int.zero);
        init.AddBuilding(Names.Buildings.House, new Vector2Int(5, 2));
        init.BuildRoad(Names.Buildings.Manor, Names.Buildings.House);
        init.StartNarrative("Test");

        _map.FullRebuild(_controller.Model);
    }

#if UNITY_EDITOR
    public ICityGraph CityGraph => _controller?.Model.Map.CityGraph;
#endif
}
