using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseData : ScriptableObject
{
    public int StartingLives;
    public TurretDefenseWaveData[] Waves;
    public TurretData[] Turrets;

    Dictionary<string, TurretData> _turretNameToData = new Dictionary<string, TurretData>();
    private void OnEnable()
    {
        foreach(var t in Turrets)
        {
            _turretNameToData.Add(t.name, t);
        }
    }

    public TurretData GetTurret(string name) => _turretNameToData[name];
}
