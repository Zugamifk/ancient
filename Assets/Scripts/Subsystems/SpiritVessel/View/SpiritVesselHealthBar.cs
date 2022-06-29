using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpiritVessel.ViewModel;

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
            var model = Game.Model.GetModel<ISpiritVesselModel>().HitpointModels.GetItem(Character.Id);
            var percent = (float)model.Current / (float)model.Max;
            _healthFill.fillAmount = percent;
        }
    }
}
