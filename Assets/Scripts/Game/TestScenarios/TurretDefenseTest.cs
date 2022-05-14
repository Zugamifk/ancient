using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretDefenseTest
{
    public static void Init(Vector2Int[] pathpoints)
    {
        Game.Do(new LoadMapDataCommand());

        var pathfinder = new PathFinder();
        var pairs = pathpoints.Zip(pathpoints.Skip(1), (a, b) => (a, b));
        foreach (var pair in pairs)
        {
            Game.Do(new BuildRoadCommand(pair.a, pair.b));
        }

        Game.Do(new TurretDefenseStartGameCommand(pathpoints[0], pathpoints[1]));
        Game.Do(new TurretDefenseStartWaveCommand());
    }
}
