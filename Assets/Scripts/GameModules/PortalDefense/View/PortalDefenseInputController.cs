using PortalDefense.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.View
{
    public class PortalDefenseInputController : MonoBehaviour
    {
        Vector2 _lastMousePosition;

        private void Update()
        {
            var move = Vector2.zero;
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                move.y = 1;
            }
            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                move.x = -1;
            }
            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                move.y = -1;
            }
            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                move.x = 1;
            }

            if (move != Vector2.zero)
            {
                Game.Do(new MoveCameraCommand(move));
            }

            var position = (Vector2)UnityEngine.Input.mousePosition;
            if (UnityEngine.Input.GetMouseButton(1))
            {
                var delta = position - _lastMousePosition;
                Game.Do(new RotateCameraCommand(delta.x));
            }

            _lastMousePosition = position;
        }
    }
}
