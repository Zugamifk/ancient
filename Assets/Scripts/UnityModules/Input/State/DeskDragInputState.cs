using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DeskDragInputState : MouseInputState
{
    Vector3 _lastDragPos;
    Draggable _draggable;

    public DeskDragInputState(Draggable target)
    {
        if (CameraController.TryGetCamera(Name.Camera.Desk, out CameraController cam))
        {
            _lastDragPos = cam.GetMouseWorldPosition();
            _draggable = target;
        }
    }

    public override MouseInputState UpdateState()
    {
        if (Input.GetMouseButton(0))
        {
            if (CameraController.TryGetCamera(Name.Camera.Desk, out CameraController cam))
            {
                var mousePos = cam.GetMouseWorldPosition();
                _draggable.Root.Translate(mousePos - _lastDragPos);
                _lastDragPos = mousePos;
            }
            return this;
        } else
        {
            return new DeskInputState();
        }
    }
}