using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    class MouseController
    {
        MouseInputState _currentState;

        public MouseController()
        {
            _currentState = new DeskInputState();
        }

        public void Update()
        {
            _currentState = _currentState.UpdateState();
        }

        public void SetState(MouseInputState state)
        {
            _currentState = state;
        }
    }
}