using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IView<ITurretModel>
{
    [SerializeField]
    Identifiable _identifiable;

    Dictionary<Guid, Vector2> _guidToPosition = new Dictionary<Guid, Vector2>();

    void Update()
    {
        var turretModel = Game.Model.TurretDefense.Turrets.GetItem(_identifiable.Id);
        _guidToPosition.Clear();
        foreach(var id in turretModel.EnemiesInRange)
        {
            var pos = Game.Model.Characters.GetItem(id).Position;
            _guidToPosition[id] = Game.Model.Map.TileMapTransformer.ModelToWorld(pos);
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

    public void InitializeFromModel(ITurretModel model)
    {
        _identifiable.Id = model.Id;
        transform.position = Game.Model.Map.TileMapTransformer.GetWorldCenterOftile((Vector3Int)model.Position);
    }
}
