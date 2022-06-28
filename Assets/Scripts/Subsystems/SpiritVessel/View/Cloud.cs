using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System;
using SpiritVessel.Commands;

namespace SpiritVessel.View
{
    [RequireComponent(typeof(Identifiable))]
    public class Cloud : MonoBehaviour, IView<ILightningSkillCloudModel>
    {
        [SerializeField]
        CircleCollider2D _collider;
        [SerializeField]
        Transform _spritesRoot;
        [SerializeField]
        ParticleSystem _particles;

        float _radius;
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
            Game.Do(new UpdateLightningSkillCloudCommand(_identifiable.Id));

            var radius = model.Radius;
            if (_radius != radius)
            {
                _collider.radius = radius;
                _spritesRoot.localScale = Vector3.one * radius / 2;

                var shape = _particles.shape;
                shape.radius = radius;
                
                _radius = radius;
            }
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
