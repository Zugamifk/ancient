using UnityEngine;

public class Boot : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    AgentCollection _agentCollection;
    [SerializeField]
    NarrativeCollection _narrativeCollection;
    [SerializeField]
    TileDataCollection _tileDataCollection;
    [SerializeField]
    BuildingCollection _buildingCollection;
    [SerializeField]
    MapData _mapData;
    [SerializeField]
    DeskItemCollection _deskItemCollection;
    [SerializeField]
    BookCollection _bookCollection;
    [SerializeField]
    UnityLifecycleController _lifecycleController;
    [SerializeField]
    UpdateableGameObjectRegistry _updateableRegistry;

    [Header("Test")]
    [SerializeField]
    string _testNarrative;

    private void Start()
    {
        // Create main controllers
        var controller = new GameController(_lifecycleController, _updateableRegistry, _agentCollection, _tileDataCollection, _buildingCollection, _mapData, _narrativeCollection, _deskItemCollection, _bookCollection);

        // Start game
        DemoInit(controller);
    }

    // move to demo script
    void DemoInit(GameController controller)
    {
        var init = controller as IGameInitializer;
        init.AddBuilding(Name.Building.Manor, Vector2Int.zero);
        init.AddBuilding(Name.Building.House, new Vector2Int(5, 2));
        init.BuildRoad(Name.Building.Manor, Name.Building.House);

        if (!string.IsNullOrEmpty(_testNarrative))
        {
            init.StartNarrative(_testNarrative);
        }
    }
}
