using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMouseInput : MouseInputState
{
    protected Vector3 _startPosition;
    protected Vector3 _startDragPosition;
    protected MapInputContext _mapContext;

    public MapMouseInput(MouseInputState state, MapInputContext mapContext)
        : base(state)
    {
        _mapContext = mapContext;
        _startPosition = _context.MapCameraController.transform.localPosition;
        _startDragPosition = Input.mousePosition;
    }

    public sealed override MouseInputState UpdateState()
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
                        if (Input.GetMouseButton(0))
                        {
                            _mapContext?.CheatAction(hit.point);
                        }
                        else
                        {
                            var diff = _context.MapCameraController.GetWorldPosition(Input.mousePosition) - _context.MapCameraController.GetWorldPosition(_startDragPosition);
                            _context.MapCameraController.PanTo(_startPosition - diff);
                        }
                        return this;
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
