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
        _lastDragPos = _context.DeskCameraController.GetMouseWorldPosition();
        _draggable = target;
    }

    public override MouseInputState UpdateState()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = _context.DeskCameraController.GetMouseWorldPosition();
            _draggable.transform.Translate(mousePos - _lastDragPos);
            _lastDragPos = mousePos;
            return this;
        } else
        {
            return new IdleMouseInputState(this);
        }
    }
}