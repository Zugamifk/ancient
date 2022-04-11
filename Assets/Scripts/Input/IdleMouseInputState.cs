using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMouseInputState : MouseInputState
{
    public override MouseInputState UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseTarget = _context.CameraController.RayCast(Input.mousePosition);
            if (mouseTarget != null)
            {
                // desk draggables
                var draggable = mouseTarget.GetComponent<DraggableGameObject>();
                if (draggable != null)
                {
                    return new DragInputState(this, draggable);
                }

                // most generic handler
                var map = mouseTarget.GetComponent<IMouseInputHandler>();
                if (map != null)
                {
                    return map.GetInputState(this);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            var mouseTarget = _context.CameraController.RayCast(Input.mousePosition);
            if (mouseTarget != null)
            {
                var selectable = mouseTarget.GetComponent<ISelectable>();
                if (selectable != null)
                {
                    return selectable.Select(this);
                }
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
