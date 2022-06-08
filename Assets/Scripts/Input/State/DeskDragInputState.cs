using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DeskDragInputState : MouseInputState
{
    Vector3 _lastDragPos;
    Draggable _draggable;

    public DeskDragInputState(Draggable target)
    {
        var cam = CameraController.TryGetCamera(Name.Camera.Desk);
        _lastDragPos = cam.GetMouseWorldPosition();
        _draggable = target;
    }

    public override MouseInputState UpdateState()
    {
        if (Input.GetMouseButton(0))
        {
            var cam = CameraController.TryGetCamera(Name.Camera.Desk);
            var mousePos = cam.GetMouseWorldPosition();
            _draggable.Root.Translate(mousePos - _lastDragPos);
            _lastDragPos = mousePos;
            return this;
        } else
        {
            return new DeskInputState();
        }
    }
}