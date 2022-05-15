using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseData : ScriptableObject, IPrefabLookup
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
        Prefabs.Register<ITurretModel>(this);
    }

    public TurretData GetTurret(string name) => _turretNameToData[name];

    public GameObject GetPrefab(string key) => GetTurret(key).Prefab;
}
