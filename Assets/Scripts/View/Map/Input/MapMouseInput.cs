using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using In = UnityEngine.Input;

namespace Input
{
    public class MapMouseInput : MouseInputState
    {
        Guid _mapId;
        ITileMapTransformer _tileMapTransformer;
        protected Vector3 _startPosition;
        protected Vector3 _startDragPosition;
        IEnumerable<IMapMouseInputHandler> _inputHandlers;

        public MapMouseInput(ITileMapTransformer tileMapTransformer, IEnumerable<IMapMouseInputHandler> inputHandlers, Guid mapId)
        {
            _tileMapTransformer = tileMapTransformer;
            _inputHandlers = inputHandlers;
            _mapId = mapId;
        }

        public sealed override MouseInputState UpdateState()
        {
            if (CameraController.TryGetCamera(Name.Camera.Desk, out CameraController cam)
                && cam.RayCast(In.mousePosition, out RaycastHit hit))
            {
                var target = hit.collider.gameObject;
                var renderTex = target.GetComponent<RenderTextureRaycaster>();
                if (renderTex != null)
                {
                    if (renderTex.RayCast(hit.textureCoord, out hit))
                    {
                        if (In.GetMouseButtonUp(0))
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
            if (!CameraController.TryGetCamera(Name.Camera.City, out CameraController cam, true))
            {
                return;
            }

            if (In.GetMouseButtonDown(1))
            {
                _startPosition = cam.transform.localPosition;
                _startDragPosition = In.mousePosition;
            }
            if (In.GetMouseButton(0))
            {
                var tile = _tileMapTransformer.GetTileFromPosition(worldPosition);
                var cmd = new SetTileCommand(_mapId);
                cmd.Position = (Vector2Int)tile;
                cmd.TileType = Name.Tile.Road;
                Game.Do(cmd);
            }
            else
            if (In.GetMouseButton(1))
            {
                var diff = cam.GetWorldPosition(In.mousePosition) - cam.GetWorldPosition(_startDragPosition);
                cam.PanTo(_startPosition - diff);
            }
        }
    }
}