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

    CheatController _cheatController;
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
        _cheatController = new CheatController(_controller, _controller.Model);

        // Init scene objects
        _map.SetPrefabCollections(_prefabCollections);
        _map.SetCheatController(_cheatController);

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
        _controller.AddBuilding(Names.Buildings.Manor, Vector2Int.zero);
        _controller.AddBuilding(Names.Buildings.House, new Vector2Int(5, 2));
        _controller.BuildRoad(Names.Buildings.Manor, Names.Buildings.House);

        _controller.StartNarrative("Test");

        _map.FullRebuild(_controller.Model);
    }

#if UNITY_EDITOR
    public ICityGraph CityGraph => _controller?.Model.Map.CityGraph;
#endif
}
