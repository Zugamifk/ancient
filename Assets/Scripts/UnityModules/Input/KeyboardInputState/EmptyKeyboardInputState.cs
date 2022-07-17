using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    public class EmptyKeyboardInputState : KeyboardInputState
    {
        public override KeyboardInputState UpdateState() => this;
    }
}