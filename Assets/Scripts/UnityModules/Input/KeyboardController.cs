using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    class KeyboardController
    {
        KeyboardInputState _currentState;

        public KeyboardController()
        {
            _currentState = new EmptyKeyboardInputState();
        }

        public void Update()
        {
            _currentState = _currentState.UpdateState();
        }

        public void SetState(KeyboardInputState state)
        {
            _currentState = state;
        }
    }
}