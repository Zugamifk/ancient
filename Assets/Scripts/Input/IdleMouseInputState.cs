using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMouseInputState : MouseInputState
{
    const float DRAG_THRESHOLD=5;
    Vector3? _dragStartPos;

    public override MouseInputState UpdateState()
    {
        bool leftMouseButtonUp = Input.GetMouseButtonUp(0);
        bool rightMouseButtonUp = Input.GetMouseButtonUp(1);
        if (leftMouseButtonUp || rightMouseButtonUp)
        {
            _dragStartPos = null;

            RaycastHit hit;
            if (_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layers.Desk), out hit))
            {
                var target = hit.collider.gameObject;

                // selectable
                var selectable = target.GetComponent<Clickable>();
                if (selectable != null)
                {
                    selectable.Select(leftMouseButtonUp ? 0 : 1);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _dragStartPos = Input.mousePosition;
        }

        if(Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            var drag = (Input.mousePosition - _dragStartPos.Value).magnitude;
            if (drag < DRAG_THRESHOLD)
            {
                return this;
            }

            RaycastHit hit;
            if (_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layers.Desk), out hit))
            {
                var target = hit.collider.gameObject;

                // desk draggables
                var draggable = target.GetComponent<Draggable>();
                if (draggable != null)
                {
                    Debug.Log(draggable);
                    return new DragInputState(this, draggable);
                }

                var renderTex = target.GetComponent<RenderTextureRaycaster>();
                if (renderTex != null)
                {
                    return RayCastMap(renderTex, hit.textureCoord);
                }
            }
        }

        return this;
    }

    MouseInputState RayCastMap(RenderTextureRaycaster raycaster, Vector2 position)
    {
        RaycastHit hit;
        if (raycaster.RayCast(position, out hit))
        {
            var target = hit.collider.gameObject;

            // most generic handler
            var input = target.GetComponent<IMouseInputHandler>();
            if (input != null)
            {
                return input.GetInputState(this);
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
