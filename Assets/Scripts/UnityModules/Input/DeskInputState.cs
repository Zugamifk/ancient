using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using In = UnityEngine.Input;

namespace Input
{
    public class DeskInputState : MouseInputState
    {
        const float DRAG_THRESHOLD = 5;
        Vector3? _dragStartPos;

        public override MouseInputState UpdateState()
        {
            if (!CameraController.TryGetCamera(Name.Camera.Desk, out CameraController cam)
                || !cam.RayCast(In.mousePosition, out RaycastHit hit))
            {
                return this;
            }

            var target = hit.collider.gameObject;

            var renderTex = target.GetComponent<RenderTextureRaycaster>();
            if (renderTex != null)
            {
                return RayCastMap(renderTex, hit.textureCoord);
            }

            bool leftMouseButtonUp = In.GetMouseButtonUp(0);
            bool rightMouseButtonUp = In.GetMouseButtonUp(1);
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

            if (In.GetMouseButtonDown(0) || In.GetMouseButtonDown(1))
            {
                _dragStartPos = In.mousePosition;
            }

            if (_dragStartPos.HasValue && (In.GetMouseButton(0) || In.GetMouseButton(1)))
            {
                // desk draggables
                var draggable = target.GetComponent<Draggable>();
                var drag = (In.mousePosition - _dragStartPos.Value).magnitude;
                if (draggable != null && drag >= DRAG_THRESHOLD)
                {
                    return new DeskDragInputState(draggable);
                }
            }

            return this;
        }

        MouseInputState RayCastMap(RenderTextureRaycaster raycaster, Vector2 position)
        {
            RaycastHit hit;
            if (!raycaster.RayCast(position, out hit))
            {
                return this;
            }

            var target = hit.collider.gameObject;
            var input = target.GetComponent<IMouseInputHandler>();
            if (input != null)
            {
                return input.GetInputState(this);
            }

            return this;
        }
    }
}