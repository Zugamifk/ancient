using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMouseInputState : MouseInputState
{
    public override MouseInputState UpdateState()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layers.Desk), out hit))
            {
                var target = hit.collider.gameObject;
                var renderTex = target.GetComponent<RenderTextureRaycaster>();
                if (renderTex != null)
                {
                    return RaycastMap(renderTex, hit.textureCoord);
                }
            }
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    var mouseTarget = _context.CameraController.RayCast(Input.mousePosition);
        //    if (mouseTarget != null)
        //    {
        //        var selectable = mouseTarget.GetComponent<ISelectable>();
        //        if (selectable != null)
        //        {
        //            return selectable.Select(this);
        //        }
        //    }
        //}
        return this;
    }

    MouseInputState RaycastMap(RenderTextureRaycaster raycaster, Vector2 position)
    {
        RaycastHit hit;
        if (raycaster.Raycast(position, out hit))
        {
            var target = hit.collider.gameObject;

            // desk draggables
            var draggable = target.GetComponent<DraggableGameObject>();
            if (draggable != null)
            {
                return new DragInputState(this, draggable);
            }

            // most generic handler
            var input = target.GetComponent<IMouseInputHandler>();
            if (input != null)
            {
                return input.GetInputState(this);
            }
        }

        return this;
    }

    public IdleMouseInputState(MouseInputState inputState)
        : base(inputState)
    {
    }

    public IdleMouseInputState(InputStateContext context) : base(context) { }
}
