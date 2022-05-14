using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour, IView<ITurretProjectileModel>
{
    [SerializeField]
    Transform _viewRoot;

    Identifiable _identifiable;

    void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
    }

    public void InitializeFromModel(ITurretProjectileModel model)
    {
        throw new System.NotImplementedException();
    }
}
