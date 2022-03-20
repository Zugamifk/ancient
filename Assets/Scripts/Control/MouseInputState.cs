using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputState
{
    public virtual MouseInputState Drag()
    {
        return this;
    }

    public virtual MouseInputState MouseDown()
    {
        return this;
    }

    public virtual MouseInputState MouseUp()
    {
        return this;
    }
}
