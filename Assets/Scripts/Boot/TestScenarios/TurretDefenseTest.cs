using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretDefenseTest
{
    public static void Init(ICommandService cmd, Vector2Int[] pathpoints)
    {
        var pathfinder = new PathFinder();
        var pairs = pathpoints.Zip(pathpoints.Skip(1), (a, b) => (a, b));
        foreach(var pair in pairs)
        {
            cmd.DoCommand(new BuildRoadCommand(pair.a, pair.b));
        }

        cmd.DoCommand(new TurretDefenseStartGameCommand());
        cmd.DoCommand(new TurretDefenseStartWaveCommand());
    }
}
