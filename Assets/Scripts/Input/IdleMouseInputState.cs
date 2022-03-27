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
                return new DragInputState(draggable, _context.CameraController);
            }

            var map = mouseTarget.GetComponent<IMouseInputHandler>();
            if (map != null)
            {
                return map.GetInputState();
            }
        }
        return this;
    }


    public IdleMouseInputState(CameraController cameraController)
        : base(cameraController)
    {
    }

    public IdleMouseInputState(InputStateContext context) : base(context) { }
}
