using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNarrativeTest : MonoBehaviour
{
    [SerializeField]
    string _narrative;

    void Start()
    {
        Game.Do(new LoadMapDataCommand());
        Game.Do(new SpawnBuildingCommand(Name.Building.Manor, Vector2Int.zero));
        Game.Do(new SpawnBuildingCommand(Name.Building.House, new Vector2Int(5, 2)));
        Game.Do(new BuildRoadCommand(Name.Building.Manor, Name.Building.House));
        Game.Do(new GenerateCityCommand());
        Game.Do(new GetItemCommand("Clock"));
        Game.Do(new GetItemCommand("TestBook"));
        Game.Do(new StartNarrativeCommand(_narrative));
    }
}
