using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNarrativeTest
{
    public static void Init(ICommandService cmd, string narrative)
    {
        cmd.DoCommand(new SpawnBuildingCommand(Name.Building.Manor, Vector2Int.zero));
        cmd.DoCommand(new SpawnBuildingCommand(Name.Building.House, new Vector2Int(5, 2)));
        cmd.DoCommand(new BuildRoadCommand(Name.Building.Manor, Name.Building.House));
        cmd.DoCommand(new GenerateCityCommand());
        cmd.DoCommand(new GetItemCommand("Clock"));
        cmd.DoCommand(new GetItemCommand("TestBook"));

        cmd.DoCommand(new StartNarrativeCommand(narrative));
    }
}
