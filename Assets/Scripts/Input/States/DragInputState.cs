using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DragInputState : MouseInputState
{
    Vector3 _lastDragPos;
    DraggableGameObject _draggable;

    public DragInputState(MouseInputState state, DraggableGameObject target)
        : base(state)
    {
        _lastDragPos = _context.CameraController.GetMouseWorldPosition();
        _draggable = target;
    }
    public override MouseInputState Drag()
    {
        var mousePos = _context.CameraController.GetMouseWorldPosition();
        _draggable.transform.Translate(mousePos - _lastDragPos);
        _lastDragPos = mousePos;
        return this;
    }

    public override MouseInputState MouseUp()
    {
        return new IdleMouseInputState(this);
    }
}