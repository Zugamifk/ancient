using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMouseInputState : MouseInputState
{
    public override MouseInputState MouseDown()
    {
        var mouseTarget = _context.CameraController.RayCast(Input.mousePosition);
        if (mouseTarget != null)
        {
            // desk draggables
            var draggable = mouseTarget.GetComponent<Draggable>();
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
        return this;
    }


    public override MouseInputState MouseUp()
    {
        var mouseTarget = _context.CameraController.RayCast(Input.mousePosition);
        if(mouseTarget!=null)
        {
            var selectable = mouseTarget.GetComponent<ISelectable>();
            if (selectable != null)
            {
                return selectable.Select(this);
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
