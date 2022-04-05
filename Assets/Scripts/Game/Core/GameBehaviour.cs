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
    TileSprites _tileSprites;
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
            TileCollection = new TileCollection(_tileSprites)
        };
    }

    private void Start()
    {
        _map.SetPrefabCollections(_prefabCollections);
        _controller = new GameController(_agentCollection);
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
        _controller.AddAgent(Names.TestAgent);
        _controller.SetAgentPath(Names.TestAgent, Names.Buildings.Manor, Names.Buildings.House);

        _map.FullRebuild(_controller.Model);
    }

#if UNITY_EDITOR
    public ICityGraph CityGraph => _controller?.Model.Map.CityGraph;
#endif
}
