using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IModelUpdateable
{
    [SerializeField]
    Identifiable _identifiable;
    [SerializeField]
    AttackRadius _attackRadius;

    void Start()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    void IModelUpdateable.UpdateFromModel(IGameModel model)
    {
        var turretModel = model.TurretDefense.Turrets.GetItem(_identifiable.Id);
        _attackRadius.SetRadius(turretModel.AttackRadius);
    }
}
