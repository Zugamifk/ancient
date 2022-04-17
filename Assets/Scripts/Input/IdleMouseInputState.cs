using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMouseInputState : MouseInputState
{
    public override MouseInputState UpdateState()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            if (_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layers.Desk), out hit))
            {
                var target = hit.collider.gameObject;

                // selectable
                var selectable = target.GetComponent<ISelectable>();
                if (selectable != null)
                {
                    return selectable.Select(this);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layers.Desk), out hit))
            {
                var target = hit.collider.gameObject;
                
                // desk draggables
                var draggable = target.GetComponent<DraggableGameObject>();
                if (draggable != null)
                {
                    Debug.Log(draggable);
                    return new DragInputState(this, draggable);
                }

                var renderTex = target.GetComponent<RenderTextureRaycaster>();
                if (renderTex != null)
                {
                    return RayCastMap(renderTex, hit.textureCoord);
                }
            }
        }

        return this;
    }

    MouseInputState RayCastMap(RenderTextureRaycaster raycaster, Vector2 position)
    {
        RaycastHit hit;
        if (raycaster.RayCast(position, out hit))
        {
            var target = hit.collider.gameObject;

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
