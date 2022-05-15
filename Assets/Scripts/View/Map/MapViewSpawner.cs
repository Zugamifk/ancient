using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapViewSpawner<TModel, TView> : ViewSpawner<TModel, TView>
    where TModel : IIdentifiable, IKeyHolder
    where TView : MonoBehaviour, IView<TModel>, IMapObject
{
    [SerializeField]
    protected TileMapper _tileMapper;
    protected override void SpawnedView(TModel model, TView view)
    {
        view.SetTileMap(_tileMapper);
        base.SpawnedView(model, view);
    }
}
