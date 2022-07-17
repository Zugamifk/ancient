using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    public class InputController : MonoBehaviour
    {
        MouseController _mouseController;
        KeyboardController _keyboardController;

        static InputController _instance;

        public static void SetMouseInputState(MouseInputState state)
        {
            _instance._mouseController.SetState(state);
        }

        public static void SetKeyboardInputState(KeyboardInputState state)
        {
            _instance._keyboardController.SetState(state);
        }

        private void Awake()
        {
            _instance = this;
        }

        void Start()
        {
            _mouseController = new();
            _keyboardController = new();
        }

        void FixedUpdate()
        {
            _mouseController.Update();
            _keyboardController.Update();
        }
    }
}
