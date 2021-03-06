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
        [SerializeField]
        CanvasGroup _visibilityGroup;

        public SpiritHealthbars Healthbars { get; set; }
        public Character Character { get; set; }

        void Update()
        {
            if (Character == null)
            {
                Destroy(gameObject);
                return;
            }

            Healthbars.UpdatePosition(this, Character);
            UpdateHealth();
        }

        void UpdateHealth()
        {
            var model = Game.Model.GetModel<ISpiritVesselModel>().HitpointModels.GetItem(Character.Id);
            var percent = (float)model.Current / (float)model.Max;
            _visibilityGroup.alpha = Mathf.Approximately(percent, 1) ? 0 : 1;
            _healthFill.fillAmount = percent;
        }
    }
}
