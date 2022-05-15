using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IView<ITurretModel>, IMapObject
{
    [SerializeField]
    Identifiable _identifiable;

    ITurretModel _model;
    TileMapper _tileMapper;
    Dictionary<Guid, Vector2> _guidToPosition = new Dictionary<Guid, Vector2>();

    public Vector2 ModelPosition => _model.Position;

    public Transform Root => transform;

    public bool UpdatesPosition => false;

    void Update()
    {
        var turretModel = Game.Model.TurretDefense.Turrets.GetItem(_identifiable.Id);
        _guidToPosition.Clear();
        foreach(var id in turretModel.EnemiesInRange)
        {
            var pos = Game.Model.Characters.GetItem(id).Position;
            _guidToPosition[id] = _tileMapper.ModelToWorld(pos);
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
        _model = model;
    }

    public void InitializeFromTileMap(TileMapper tileMapper)
    {
        _tileMapper = tileMapper;
        transform.position = _tileMapper.GetWorldCenterOftile((Vector3Int)_model.Position);
    }
}
