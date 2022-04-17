using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    [Header("Data")]
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
    DeskItemCollection _deskItemCollection;

    [Header("Behaviours")]
    [SerializeField]
    Map _map;
    [SerializeField]
    Desk _desk;

    GameController _controller;
    PrefabCollectionSet _prefabCollections;

    private void Awake()
    {
        _prefabCollections = new PrefabCollectionSet()
        {
            BuildingCollection = _buildingCollection,
            AgentCollection = _agentCollection,
            DeskItemCollection = _deskItemCollection,
            TileBuilder = _tileDataCollection
        };
    }

    private void Start()
    {
        // Create main controllers
        _controller = new GameController(_agentCollection, _tileDataCollection, _mapData, _narrativeCollection, _deskItemCollection);

        // Init scene objects
        _map.SetPrefabCollections(_prefabCollections);
        _desk.SetPrefabCollections(_prefabCollections);

        // Start game
        DemoInit();
    }

    private void Update()
    {
        _controller.Frameupdate(Time.deltaTime);
        _map.FrameUpdate(_controller.Model);
        _desk.FrameUpdate(_controller.Model);
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
