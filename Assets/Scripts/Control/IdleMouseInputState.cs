using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMouseInputState : MouseInputState
{
    public override MouseInputState MouseDown()
    {
        var mouseTarget = Services.Find<CameraController>().GetMouseTarget(Input.mousePosition);
        if (mouseTarget != null)
        {
            var draggable = mouseTarget.GetComponent<Draggable>();
            if (draggable != null)
            {
                return Services.Find<DragController>().StartDragging(draggable);
            }

            var map = mouseTarget.GetComponent<Map>();
            if(map!=null)
            {
                return map.StartMapping();
            }
        }
        return this;
    }
}
