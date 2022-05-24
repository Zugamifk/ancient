using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IView<ITurretModel>, IMapObject
{
    [SerializeField]
    Identifiable _identifiable;

    ITurretModel _model;
    ITileMapTransformer _tileMap;
    Dictionary<Guid, Vector2> _guidToPosition = new Dictionary<Guid, Vector2>();

    void Update()
    {
        var turretModel = Game.Model.TurretDefense.Turrets.GetItem(_identifiable.Id);
        _guidToPosition.Clear();
        foreach(var id in turretModel.EnemiesInRange)
        {
            var character = Game.Model.Characters.GetItem(id);
            if(character!=null)
            {   
                _guidToPosition[id] = _tileMap.ModelToWorld(character.Position);
            }
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
        transform.position = _tileMap.GetWorldCenterOftile((Vector3Int)_model.Position);    
    }

    public void SetTileMap(ITileMapTransformer tileMap)
    {
        _tileMap = tileMap;
    }
}
