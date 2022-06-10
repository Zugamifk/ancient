using Map.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map.View
{
    public class MapMouseInput : MouseInputState
    {
        ITileMapTransformer _tileMapTransformer;
        protected Vector3 _startPosition;
        protected Vector3 _startDragPosition;
        IEnumerable<IMapMouseInputHandler> _inputHandlers;

        public MapMouseInput(ITileMapTransformer tileMapTransformer, IEnumerable<IMapMouseInputHandler> inputHandlers)
        {
            _tileMapTransformer = tileMapTransformer;
            _inputHandlers = inputHandlers;
        }

        public sealed override MouseInputState UpdateState()
        {
            var cam = CameraController.TryGetCamera(Name.Camera.Desk);
            RaycastHit hit;
            if (cam.RayCast(Input.mousePosition, out hit))
            {
                var target = hit.collider.gameObject;
                var renderTex = target.GetComponent<RenderTextureRaycaster>();
                if (renderTex != null)
                {
                    if (renderTex.RayCast(hit.textureCoord, out hit))
                    {
                        if (Input.GetMouseButtonUp(0))
                        {
                            target = hit.collider.gameObject;
                            var clickable = target.GetComponent<Clickable>();
                            if (clickable != null)
                            {
                                clickable.Select(0);
                                return this;
                            }
                        }

                        MapHandleMouse(hit.point);
                        return this;
                    }
                }
            }

            return new DeskInputState();
        }

        void MapHandleMouse(Vector3 worldPosition)
        {
            foreach (var handler in _inputHandlers)
            {
                if (handler.ShouldHandleInput(worldPosition))
                {
                    handler.HandleInput(worldPosition);
                    return;
                }
            }

            DefaultHandInput(worldPosition);
        }

        void DefaultHandInput(Vector3 worldPosition)
        {
            var cam = CameraController.TryGetCamera(Name.Camera.Map);
            if (Input.GetMouseButtonDown(1))
            {
                _startPosition = cam.transform.localPosition;
                _startDragPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                var tile = _tileMapTransformer.GetTileFromPosition(worldPosition);
                Game.Do(new SetTileCommand()
                {
                    Position = (Vector2Int)tile,
                    TileType = Name.Tile.Road
                });
            }
            else
            if (Input.GetMouseButton(1))
            {
                var diff = cam.GetWorldPosition(Input.mousePosition) - cam.GetWorldPosition(_startDragPosition);
                cam.PanTo(_startPosition - diff);
            }
        }
    }
}