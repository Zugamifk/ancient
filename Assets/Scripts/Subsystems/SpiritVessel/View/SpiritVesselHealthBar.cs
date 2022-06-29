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

        public void SetHealthPercent(float percent)
        {
            _healthFill.fillAmount = percent;
        }
    }
}
