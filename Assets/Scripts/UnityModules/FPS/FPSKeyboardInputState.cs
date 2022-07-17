using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;

namespace FPS
{
    public class FPSKeyboardInputState : KeyboardInputState
    {
        public override KeyboardInputState UpdateState()
        {
            return this;
        }
    }
}