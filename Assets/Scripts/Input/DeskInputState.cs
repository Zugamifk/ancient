using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInputState : MouseInputState
{
    const float DRAG_THRESHOLD = 5;
    Vector3? _dragStartPos;

    public override MouseInputState UpdateState()
    {
        if (!CameraController.TryGetCamera(Name.Camera.Desk, out CameraController cam) 
            || !cam.RayCast(Input.mousePosition, out RaycastHit hit))
        {
            return this;
        }

        var target = hit.collider.gameObject;

        var renderTex = target.GetComponent<RenderTextureRaycaster>();
        if (renderTex != null)
        {
            return RayCastMap(renderTex, hit.textureCoord);
        }

        bool leftMouseButtonUp = Input.GetMouseButtonUp(0);
        bool rightMouseButtonUp = Input.GetMouseButtonUp(1);
        if (leftMouseButtonUp || rightMouseButtonUp)
        {
            _dragStartPos = null;

            // selectable
            var clickable = target.GetComponent<Clickable>();
            if (clickable != null)
            {
                clickable.Select(leftMouseButtonUp ? 0 : 1);
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _dragStartPos = Input.mousePosition;
        }

        if (_dragStartPos.HasValue && ( Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            // desk draggables
            var draggable = target.GetComponent<Draggable>();
            var drag = (Input.mousePosition - _dragStartPos.Value).magnitude;
            if (draggable != null && drag >= DRAG_THRESHOLD)
            {
                return new DeskDragInputState(draggable);
            }
        }

        return this;
    }

    MouseInputState RayCastMap(RenderTextureRaycaster raycaster, Vector2 position)
    {
        Debug.Log("Raycast map");

        RaycastHit hit;
        if (!raycaster.RayCast(position, out hit))
        {
            return this;
        }

        Debug.Log("Raycast IMouseInputHandler");

        var target = hit.collider.gameObject;
        var input = target.GetComponent<IMouseInputHandler>();
        if (input != null)
        {
            return input.GetInputState(this);
        }

        return this;
    }
}
