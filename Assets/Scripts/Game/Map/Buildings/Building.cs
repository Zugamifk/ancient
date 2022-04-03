using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IMouseInputHandler
{
    class InputState : MouseInputState
    {
        public InputState(InputStateContext context) : base(context) { }
    }

    [SerializeField]
    Transform _Entrance;

    public Vector3 EntrancePosition => _Entrance.position;

    IBuildingBehaviour _building;
    private void Start()
    {
        _building = GetComponent<IBuildingBehaviour>();
    }

    public MouseInputState GetInputState(MouseInputState state)
    {
        throw new System.NotImplementedException();
    }
}
