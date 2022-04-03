using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, ISelectable
{
    [SerializeField]
    Transform _Entrance;

    public Vector3 EntrancePosition => _Entrance.position;

    IBuildingBehaviour _building;
    private void Start()
    {
        _building = GetComponent<IBuildingBehaviour>();
    }

    public MouseInputState Select(MouseInputState current)
    {
        throw new System.NotImplementedException();
    }
}
