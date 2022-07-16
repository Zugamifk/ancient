using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SpiritVessel.ViewModel;
using SpiritVessel.Data;
using SpiritVessel.Commands;

namespace SpiritVessel.View
{
    public class SpiritVesselUILevelUp : MonoBehaviour
    {
        [System.Serializable]
        public class LevelUpOptionButton
        {
            public Image icon;
            public Button button;
            [System.NonSerialized]
            public string skillKey;
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
                _levelUpOptionButtons[i].skillKey = name;
            }

            ShowSkillInfo(0);
        }

        public void OnHoverSkillOptions(int optionIndex)
        {
            ShowSkillInfo(optionIndex);
        }

        void ShowSkillInfo(int optionIndex)
        {
            var skills = DataService.GetData<SpiritVesselSkillCollection>();
            var skillData = skills.GetData(_levelUpOptionButtons[optionIndex].skillKey);
            _name.text = skillData.DisplayName;
            _description.text = skillData.Description;
        }

        public void ChooseOption(int optionIndex)
        {
            Game.Do(new CompleteLevelUpSelectionCommand(_levelUpOptionButtons[optionIndex].skillKey));
            gameObject.SetActive(false);
        }
    }
}
