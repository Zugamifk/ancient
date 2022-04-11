using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MouseInputState
{
    protected InputStateContext _context;

    protected MouseInputState(InputStateContext context)
    {
        _context = context;
    }

    public MouseInputState(MouseInputState state) : this(state._context) { }

    public abstract MouseInputState UpdateState();
}
