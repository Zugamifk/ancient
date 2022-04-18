using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMouseInput : MouseInputState
{
    bool _dragging;
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
                        if(leftButtonDown) { 
                            _map.SetTile(hit.point, Name.Tile.Road);
                        } else
                        {
                            if (_dragging) { 
                                var dp = hit.point;
                                var diff = dp - _startDragPosition;
                                var newPos = _startPosition - diff;
                                _context.MapCameraController.PanTo(newPos);
                            }else
                            {
                                _startDragPosition = hit.point;
                                _dragging = true;
                            }
                        }
                    }
                }
            }
            return this;
        }
        else if (Input.GetMouseButton(1))
        {
            //var dp = _context.MapCameraController.GetMouseWorldPosition();
            //var diff = dp - _startDragPosition;
            //var newPos = _startPosition - diff;
            //Debug.DrawLine()
            //_context.MapCameraController.PanTo(newPos);
            return this;
        }
        else
        {
            return new IdleMouseInputState(this);
        }
    }
}
