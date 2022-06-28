using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        }
    }
}
