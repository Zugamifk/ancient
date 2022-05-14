using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapViewSpawner<TModel, TView> : ViewSpawner<TModel, TView>
    where TModel : IIdentifiable, IKeyHolder
    where TView : MonoBehaviour, IView<TModel>, ITileMapObject
{
    protected TileMapper _tileMapper;
    public void SetTileMapper(TileMapper tileMapper)
    {
        _tileMapper = tileMapper;
    }
    protected override void SpawnedView(TModel model, TView view)
    {
        view.InitializeFromTileMap(_tileMapper);
        base.SpawnedView(model, view);
    }
}
