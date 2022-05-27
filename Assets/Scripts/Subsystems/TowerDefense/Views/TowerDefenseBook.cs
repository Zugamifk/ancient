using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace TowerDefense.Views
{
    public class TowerDefenseBook : MonoBehaviour
    {
        const string k_LivesTextString = "LIVES: {0}/{1}";
        const string k_WaveCountTextString = "WAVE {0}";
        const string k_TimeTextString = "TIME: {0}";

        [SerializeField]
        TextMeshProUGUI _livesText;
        [SerializeField]
        TextMeshProUGUI _waveCountText;
        [SerializeField]
        TextMeshProUGUI _timeText;
        [SerializeField]
        string[] _buildingOptions;

        public void Update()
        {
            var tdModel = Game.Model.TowerDefense;
            _livesText.text = string.Format(k_LivesTextString, tdModel.Lives, tdModel.MaxLives);
            _waveCountText.text = string.Format(k_WaveCountTextString, tdModel.CurrentWave + 1);
            _timeText.text = string.Format(k_TimeTextString, tdModel.CurrentTime.ToString(@"mm\:ss"));
        }

        public void ClickedBuildOption(int index)
        {
            Game.Do(new StartPlacingTowerCommand(_buildingOptions[index]));
        }
    }
}