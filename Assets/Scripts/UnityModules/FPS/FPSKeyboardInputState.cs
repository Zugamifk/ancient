using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;

namespace FPS
{
    public class FPSKeyboardInputState : KeyboardInputState
    {
        MovementModel _moveModel;

        public FPSKeyboardInputState(MovementModel model)
        {
            _moveModel = model;
        }

        public override KeyboardInputState UpdateState()
        {
            _moveModel.Movement = new Vector2()
            {
                x = UnityEngine.Input.GetAxis("Horizontal"),
                y = UnityEngine.Input.GetAxis("Vertical"),
            };
            return this;
        }
    }
}