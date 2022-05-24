using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Views
{
    public class TurretProjectile : MonoBehaviour, IView<IProjectile>
    {
        [SerializeField]
        Transform _viewRoot;

        Identifiable _identifiable;

        void Awake()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        public void InitializeFromModel(IProjectile model)
        {
            throw new System.NotImplementedException();
        }
    }
}