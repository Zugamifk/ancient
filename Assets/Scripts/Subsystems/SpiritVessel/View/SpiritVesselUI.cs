using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpiritVessel.ViewModel;

namespace SpiritVessel.View
{
    public class SpiritVesselUI : MonoBehaviour
    {
        [SerializeField]
        Image _xpBar;
        [SerializeField]
        Image[] _dangerLevelIcons;

        private void Update()
        {
            var model = Game.Model.GetModel<ISpiritVesselModel>();
            var xp = model.Experience;
            var needed = model.ExperienceNeeded;
            var percent = xp / needed;
            _xpBar.fillAmount = percent;
        }
    }
}
