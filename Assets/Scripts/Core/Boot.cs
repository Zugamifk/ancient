using UnityEngine;

public class Boot : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    CharacterCollection _agentCollection;
    [SerializeField]
    NarrativeCollection _narrativeCollection;
    [SerializeField]
    TileDataCollection _tileDataCollection;
    [SerializeField]
    BuildingCollection _buildingCollection;
    [SerializeField]
    MapData _mapData;
    [SerializeField]
    ItemCollection _deskItemCollection;
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
        var controller = new GameController(
            _lifecycleController, 
            _updateableRegistry, 
            _agentCollection, 
            _tileDataCollection, 
            _buildingCollection, 
            _mapData, 
            _narrativeCollection, 
            _deskItemCollection);

        // Start game
        DemoInit(controller);
    }

    // move to demo script
    void DemoInit(GameController controller)
    {
        var cmd = controller as ICommandService;
        cmd.DoCommand(new SpawnBuildingCommand(Name.Building.Manor, Vector2Int.zero));
        cmd.DoCommand(new SpawnBuildingCommand(Name.Building.House, new Vector2Int(5, 2)));
        cmd.DoCommand(new BuildRoadCommand(Name.Building.Manor, Name.Building.House));
        cmd.DoCommand(new GetItemCommand("Clock"));
        cmd.DoCommand(new GetItemCommand("TestBook"));

        if (!string.IsNullOrEmpty(_testNarrative))
        {
            cmd.DoCommand(new StartNarrativeCommand(_testNarrative));
        }
    }
}
