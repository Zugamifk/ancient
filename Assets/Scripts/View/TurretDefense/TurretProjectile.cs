using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour, IModelUpdateable, IView<ITurretProjectileModel>
{
    [SerializeField]
    Transform _viewRoot;

    Identifiable _identifiable;

    void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
    }

    public void UpdateFromModel(IGameModel model)
    {
        throw new System.NotImplementedException();
    }

    public void InitializeFromModel(IGameModel gamemodel, ITurretProjectileModel model)
    {
        throw new System.NotImplementedException();
    }
}
