using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TowerDefense.Data;
using TowerDefense.ViewModel;

namespace TowerDefense.Views
{
    public class TowerDefenseBook : MonoBehaviour
    {
        const string k_LivesTextString = "LIVES: {0}/{1}";
        const string k_WaveCountTextString = "WAVE {0}";
        const string k_TimeTextString = "TIME: {0}";
        const string k_CoinsTextString = "COINS: {0}";

        [SerializeField]
        TextMeshProUGUI _livesText;
        [SerializeField]
        TextMeshProUGUI _waveCountText;
        [SerializeField]
        TextMeshProUGUI _timeText;
        [SerializeField]
        NumberRoll _coinsText;
        [SerializeField]
        TowerDefenseBuildTowerButton[] _buildTowerButtons;

        int _lastUpdatedCoinAmount;

        private void Start()
        {
            var data = DataService.GetData<TowerDefenseData>();
            for(int i = 0; i < data.Towers.Length; i++)
            {
                _buildTowerButtons[i].SetTower(data.Towers[i]);
            }
            _coinsText.SetTextFormat(k_CoinsTextString);
        }

        public void Update()
        {
            var tdModel = Game.Model.GetModel<ITowerDefense>();
            _livesText.text = string.Format(k_LivesTextString, tdModel.Lives, tdModel.MaxLives);
            _waveCountText.text = string.Format(k_WaveCountTextString, tdModel.CurrentWave + 1);
            _timeText.text = string.Format(k_TimeTextString, tdModel.CurrentTime.ToString(@"mm\:ss"));
            if (_lastUpdatedCoinAmount != tdModel.Coins)
            {
                OnCoinsChanged();
            }
        }

        void OnCoinsChanged()
        {
            var tdModel = Game.Model.GetModel<ITowerDefense>();
            _coinsText.SetTarget(tdModel.Coins);
            for (int i = 0; i < _buildTowerButtons.Length; i++)
            {
                _buildTowerButtons[i].UpdateState();
            }
            _lastUpdatedCoinAmount = tdModel.Coins;
        }
    }
}