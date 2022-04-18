using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMouseInput : MouseInputState
{
    Vector3 _startPosition;
    Vector3 _startDragPosition;
    Map _map;

    public MapMouseInput(MouseInputState state, Map map)
        : base(state)
    {
        _map = map;
        _startPosition = _context.MapCameraController.transform.localPosition;
        _startDragPosition = Input.mousePosition;
    }

    public override MouseInputState UpdateState()
    {
        bool leftButtonDown = Input.GetMouseButton(0);
        bool rightButtonDown = Input.GetMouseButton(1);
        if (leftButtonDown || rightButtonDown)
        {
            RaycastHit hit;
            if (_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layer.Desk), out hit))
            {
                var target = hit.collider.gameObject;
                var renderTex = target.GetComponent<RenderTextureRaycaster>();
                if (renderTex != null)
                {
                    if (renderTex.RayCast(hit.textureCoord, out hit))
                    {
                        if (leftButtonDown)
                        {
                            _map.SetTile(hit.point, Name.Tile.Road);
                        }
                        else
                        {
                            var diff = _context.MapCameraController.GetWorldPosition(Input.mousePosition) - _context.MapCameraController.GetWorldPosition(_startDragPosition);
                            _context.MapCameraController.PanTo(_startPosition - diff);
                        }
                    }
                }
            }
            return this;
        }
        else
        {
            return new IdleMouseInputState(this);
        }
    }
}
