using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModel;

namespace TowerDefense.Views
{
    public class Projectile : MonoBehaviour, IView<IProjectile>
    {
        [SerializeField]
        Transform _viewRoot;

        Identifiable _identifiable;
        ITileMapTransformer _tileMapper;

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