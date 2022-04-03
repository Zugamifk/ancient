using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMouseInputState : MouseInputState
{
    public override MouseInputState MouseDown()
    {
        var mouseTarget = _context.CameraController.RayCast(UnityEngine.Input.mousePosition);
        if (mouseTarget != null)
        {
            var draggable = mouseTarget.GetComponent<Draggable>();
            if (draggable != null)
            {
                return new DragInputState(this, draggable);
            }

            var map = mouseTarget.GetComponent<IMouseInputHandler>();
            if (map != null)
            {
                return map.GetInputState(this);
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
