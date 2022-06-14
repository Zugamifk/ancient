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
        IMapCommandFactory _commandFactory;

        public MapMouseInput(ITileMapTransformer tileMapTransformer, IEnumerable<IMapMouseInputHandler> inputHandlers, IMapCommandFactory commandFactory)
        {
            _tileMapTransformer = tileMapTransformer;
            _inputHandlers = inputHandlers;
            _commandFactory = commandFactory;
        }

        public sealed override MouseInputState UpdateState()
        {
            if (CameraController.TryGetCamera(Name.Camera.Desk, out CameraController cam) 
                && cam.RayCast(Input.mousePosition, out RaycastHit hit))
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
            if(!CameraController.TryGetCamera(Name.Camera.City, out CameraController cam, true))
            {
                return;
            }

            if (Input.GetMouseButtonDown(1))
            {
                _startPosition = cam.transform.localPosition;
                _startDragPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                var tile = _tileMapTransformer.GetTileFromPosition(worldPosition);
                var cmd = _commandFactory.GetCommand<SetTileCommand>();
                cmd.Position = (Vector2Int)tile;
                cmd.TileType = Name.Tile.Road;
                Game.Do(cmd);
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