using System.Collections;
using System.Collections.Generic;
using TowerDefense.Data;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.ViewModel;

namespace TowerDefense.Views
{
    public class TowerDefenseBuildTowerButton : MonoBehaviour
    {
        [SerializeField]
        Image _towerIcon;

        Button _button;
        TowerData _tower;

        void Awake()
        {
            _button = GetComponent<Button>();
            _button.enabled = false;
            _button.onClick.AddListener(Clicked);
        }

        public void SetTower(TowerData tower)
        {
            _tower = tower;
            _towerIcon.sprite = tower.Sprite;
            UpdateState();
        }

        public void UpdateState()
        {
            _button.enabled = _tower!=null 
                && Game.Model.GetModel<ITowerDefense>().Coins >= _tower.BuildCost;
        }

        void Clicked()
        {
            Game.Do(new StartPlacingTowerCommand(_tower.Name));
        }
    }
}
