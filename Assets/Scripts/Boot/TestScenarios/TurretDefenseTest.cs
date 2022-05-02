using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseTest
{
    public static void Init(ICommandService cmd)
    {
        cmd.DoCommand(new TurretDefenseStartGameCommand());
        cmd.DoCommand(new TurretDefenseStartWaveCommand());
    }
}
