using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController
{
    class MouseDragHandler : MouseInputState
    {
        Vector3 _lastDragPos;
        Draggable _draggable;
        public MouseDragHandler(Draggable target)
        {
            _lastDragPos = Services.Find<CameraController>().GetMouseWorldPosition();
            _draggable = target;
        }
        public override MouseInputState Drag()
        {
            var mousePos = Services.Find<CameraController>().GetMouseWorldPosition();
            _draggable.transform.Translate(mousePos - _lastDragPos);
            _lastDragPos = mousePos;
            return this;
        }

        public override MouseInputState MouseUp()
        {
            return new IdleMouseInputState();
        }
    }

    public MouseInputState StartDragging(Draggable draggable)
    {
        Debug.Log("DRAGGING " + draggable);
        return new MouseDragHandler(draggable);
    }
}
