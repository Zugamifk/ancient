using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System;

namespace SpiritVessel.View
{
    [RequireComponent(typeof(Identifiable))]
    public class Cloud : MonoBehaviour, IView<ILightningSkillCloudModel>
    {
        Identifiable _identifiable;
        HashSet<Guid> _containedSpirits = new();
        public void InitializeFromModel(ILightningSkillCloudModel model)
        {
            _identifiable.Id = model.Id;
        }

        private void Awake()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        void Update()
        {
            var model = Game.Model.GetModel<ISpiritVesselModel>().LightningSkill.Clouds.GetItem(_identifiable.Id);
            Debug.Log(_containedSpirits.Count);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var enemy = collision.gameObject.GetComponent<Spirit>();
            if (enemy != null)
            {
                _containedSpirits.Add(enemy.Id);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var enemy = collision.gameObject.GetComponent<Spirit>();
            if (enemy != null)
            {
                _containedSpirits.Remove(enemy.Id);
            }
        }
    }
}
