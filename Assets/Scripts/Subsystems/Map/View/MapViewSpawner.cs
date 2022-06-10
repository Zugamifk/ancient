using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.View
{
    public abstract class MapViewSpawner<TModel, TView> : ViewSpawner<TModel, TView>
        where TModel : IIdentifiable, IKeyHolder, IMapPositionable
        where TView : MonoBehaviour, IView<TModel>
    {
        [SerializeField]
        protected TileMapper _tileMapper;
        protected override void SpawnedView(TModel model, TView view)
        {
            base.SpawnedView(model, view);

            var positionable = view.GetComponent<MapPositionable>();
            positionable.PositionGetter = GetPosition;
        }

        Vector3 GetPosition(Guid id)
        {
            var positionable = GetIdentifiables().GetItem(id); ;
            if (positionable != null)
            {
                return _tileMapper.ModelToWorld(positionable.Position);
            }
            return Vector3.zero;
        }
    }
}