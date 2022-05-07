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
    [SerializeField]
    TurretDefenseData _turretDefenseData;

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
            _deskItemCollection,
            _turretDefenseData);

        // Start game
        //SimpleNarrativeTest.Init(controller, _testNarrative);
        TurretDefenseTest.Init(controller, new Vector2Int[] { new Vector2Int(1,1), new Vector2Int(10, 0) });
    }
}
