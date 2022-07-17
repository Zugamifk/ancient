using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    public class InputController : MonoBehaviour
    {
        MouseController _mouseController;

        static InputController _instance;

        public static void SetMouseInputState(MouseInputState state)
        {
            _instance._mouseController.SetState(state);
        }

        private void Awake()
        {
            _instance = this;
        }

        void Start()
        {
            _mouseController = new MouseController();
        }

        void FixedUpdate()
        {
            _mouseController.Update();
        }
    }
}
