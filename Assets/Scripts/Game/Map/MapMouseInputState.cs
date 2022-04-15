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
        _startPosition = _context.MapCameraController.transform.position;
        _startDragPosition = _context.MapCameraController.GetMouseWorldPosition();
    }

    public override MouseInputState UpdateState()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layers.Desk), out hit))
            {
                var target = hit.collider.gameObject;
                var renderTex = target.GetComponent<RenderTextureRaycaster>();
                if (renderTex != null)
                {
                    if (renderTex.Raycast(hit.textureCoord, out hit))
                    {
                        _map.SetTile(hit.point, Names.Tiles.Road);
                    }
                }
            }
            return this;
        }
        else if (Input.GetMouseButton(1))
        {
            var dp = _context.MapCameraController.GetMouseWorldPosition();
            var diff = dp - _startDragPosition;
            var newPos = _startPosition - diff;
            _context.MapCameraController.PanTo(newPos);
            return this;
        }
        else
        {
            return new IdleMouseInputState(this);
        }
    }
}
