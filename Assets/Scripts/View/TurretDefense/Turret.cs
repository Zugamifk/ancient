using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IModelUpdateable
{
    [SerializeField]
    Identifiable _identifiable;
    [SerializeField]
    AttackRadius _attackRadius;

    void Awake()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    public void UpdateFromModel(IGameModel model)
    {
        throw new System.NotImplementedException();
    }
}
