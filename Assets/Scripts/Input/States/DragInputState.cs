using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DragInputState : MouseInputState
{
    Vector3 _lastDragPos;
    Draggable _draggable;
    CameraController _cameraController;

    public DragInputState(Draggable target, CameraController cameraController)
        : base(cameraController)
    {
        _cameraController = cameraController;
        _lastDragPos = _cameraController.GetMouseWorldPosition();
        _draggable = target;
    }
    public override MouseInputState Drag()
    {
        var mousePos = _cameraController.GetMouseWorldPosition();
        _draggable.transform.Translate(mousePos - _lastDragPos);
        _lastDragPos = mousePos;
        return this;
    }

    public override MouseInputState MouseUp()
    {
        return new IdleMouseInputState(_cameraController);
    }
}