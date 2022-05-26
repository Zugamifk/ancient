using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Views
{
    public class Projectile : MonoBehaviour, IView<IProjectile>
    {
        [SerializeField]
        Transform _viewRoot;

        Identifiable _identifiable;

        void Awake()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        void IView<IProjectile>.InitializeFromModel(IProjectile model)
        {
            _identifiable.Id = model.Id;
        }
    }
}