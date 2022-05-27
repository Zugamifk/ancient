using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Views
{
    public class Tower : MonoBehaviour, IView<ITower>
    {
        [SerializeField]
        Identifiable _identifiable;

        public void InitializeFromModel(ITower model)
        {
            _identifiable.Id = model.Id;
        }
    }
}