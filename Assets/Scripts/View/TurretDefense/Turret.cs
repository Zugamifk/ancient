using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IModelUpdateable
{
    [SerializeField]
    Identifiable _identifiable;

    Dictionary<Guid, Vector2> _guidToPosition = new Dictionary<Guid, Vector2>();

    void Start()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    void IModelUpdateable.UpdateFromModel(IGameModel model)
    {
        var turretModel = model.TurretDefense.Turrets.GetItem(_identifiable.Id);
        _guidToPosition.Clear();
        foreach(var id in turretModel.EnemiesInRange)
        {
            var pos = model.Characters.GetItem(id).Position;
            _guidToPosition[id] = model.Map.TileMapTransformer.ModelToWorld(pos);
        }
    }

    void OnDrawGizmos()
    {
        var pos = transform.position;
        foreach(var kv in _guidToPosition)
        {
            Debug.DrawLine(pos, kv.Value);
        }
    }
}
