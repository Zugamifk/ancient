using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;

namespace FPS
{
    public class FPSDemo : MonoBehaviour
    {
        [SerializeField]
        Transform _lookRoot;
        [SerializeField]
        Transform _moveRoot;
        [SerializeField]
        Rigidbody _moveBody;

        LookModel _look = new();
        MovementModel _move = new();

        void Start()
        {
            var mouse = new FPSMouseInputState(_look);
            InputController.SetMouseInputState(mouse);
            var keyboard = new FPSKeyboardInputState(_move);
            InputController.SetKeyboardInputState(keyboard);
        }

        private void FixedUpdate()
        {
            _lookRoot.localRotation = Quaternion.AngleAxis(_look.LookAngles.x, Vector3.right);
            _moveRoot.localRotation = Quaternion.AngleAxis(_look.LookAngles.y, Vector3.up);

            var y = _moveBody.velocity.y;
            var s = _move.Movement * _move.MoveSpeed * Time.deltaTime;
            var tf = _moveBody.transform;
            var v = tf.forward * s.y + tf.right * s.x;
            v.y = y;
            _moveBody.velocity = v;
        }
    }
}