using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapViewSpawner<TModel, TView> : RegisteredPrefabViewSpawner<TModel, TView>
    where TModel : IIdentifiable, IKeyHolder, IMapPositionable
    where TView : MonoBehaviour, IView<TModel>
{
    [SerializeField]
    protected TileMapper _tileMapper;
    protected override void SpawnedView(TModel model, TView view)
    {
        base.SpawnedView(model, view);

        var identifiable = view.GetComponent<Identifiable>();
        identifiable.Id = model.Id;

        var positionable = view.GetComponent<MapPositionable>();
        positionable.PositionGetter = GetPosition;
        positionable.Update();
    }

    Vector3 GetPosition(Guid id)
    {
        var positionable = GetModel(id); ;
        if (positionable != null)
        {
            return _tileMapper.ModelToWorld(positionable.Position);
        }

        Debug.Log($"No positionable found for id {id}");

        return Vector3.zero;
    }
}
