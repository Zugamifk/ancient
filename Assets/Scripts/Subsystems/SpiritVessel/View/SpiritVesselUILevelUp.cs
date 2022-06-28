using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SpiritVessel.ViewModel;
using SpiritVessel.Data;

namespace SpiritVessel.View
{
    public class SpiritVesselUILevelUp : MonoBehaviour
    {
        [System.Serializable]
        public class LevelUpOptionButton
        {
            public Image icon;
            public Button button;
        }

        [SerializeField]
        LevelUpOptionButton[] _levelUpOptionButtons;
        [SerializeField]
        TextMeshProUGUI _name;
        [SerializeField]
        TextMeshProUGUI _description;
        [SerializeField]
        Animator _animator;

        public void ShowLevelUp()
        {
            gameObject.SetActive(true);

            var model = Game.Model.GetModel<ISpiritVesselModel>();
            var skills = DataService.GetData<SpiritVesselSkillCollection>();
            for (int i=0;i<3;i++)
            {
                var name = model.LevelUp.SkillOptions[i];
                var skillData = skills.GetData(name);

                _levelUpOptionButtons[i].icon.sprite = skillData.Icon;
            }
        }
    }
}
