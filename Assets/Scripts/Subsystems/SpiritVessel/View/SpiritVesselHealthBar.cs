using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpiritVessel.View
{
    public class SpiritVesselHealthBar : MonoBehaviour
    {
        [SerializeField]
        Image _healthFill;

        public SpiritHealthbars Healthbars {get;set;}
        public Character Character { get; set; }

        void Update()
        {
            if (Character == null)
            {
                Destroy(gameObject);
            }
            else
            {
                Healthbars.UpdatePosition(this, Character);
            }
        }

        void UpdateHealth()
        {
            var model = Game.Model.Characters.GetItem(Character.Id);
        }
    }
}
