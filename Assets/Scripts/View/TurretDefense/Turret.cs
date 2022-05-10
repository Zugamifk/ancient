using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IModelUpdateable
{
    [SerializeField]
    Identifiable _identifiable;
    [SerializeField]
    AttackRadius _attackRadius;

    HashSet<Guid> _enemiesInRange = new HashSet<Guid>();

    void Start()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
        _attackRadius.EnemyInRadius += UpdateEnemyInRange;
    }

    void UpdateEnemyInRange(Guid id, bool inRange)
    {
        if (inRange)
        {
            _enemiesInRange.Add(id);
        } else
        {
            _enemiesInRange.Remove(id);
        }
    }

    void IModelUpdateable.UpdateFromModel(IGameModel model)
    {
        var turretModel = model.TurretDefense.Turrets.GetItem(_identifiable.Id);
        _attackRadius.SetRadius(turretModel.AttackRadius);
    }
}
