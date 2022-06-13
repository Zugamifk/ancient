using System.Collections;
using System.Collections.Generic;
using TowerDefense.Commands;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Views
{
    public class TowerDefenseInput : MonoBehaviour, IMapMouseInputHandler
    {
        ITileMapTransformer _tileMapTransformer;

        public void HandleInput(Vector3 worldPosition)
        {
            if (Input.GetMouseButtonUp(1))
            {
                Game.Do(new StopPlacingTowerCommand());
            }
            else if (Input.GetMouseButtonUp(0))
            {
                var tile = _tileMapTransformer.GetTileFromPosition(worldPosition);
                Game.Do(new BuildTowerCommand(Game.Model.GetModel<ITowerDefense>().BuildingBeingPlaced, (Vector2Int)tile));
            }
        }

        public void SetTileMapTransformer(ITileMapTransformer transformer)
        {
            _tileMapTransformer = transformer;
        }

        public bool ShouldHandleInput(Vector3 position)
        {
            return !string.IsNullOrEmpty(Game.Model.GetModel<ITowerDefense>().BuildingBeingPlaced);
        }
    }
}
