using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System.Linq;

namespace SpiritVessel.View
{
    public class SpiritHealthbars : MonoBehaviour
    {
        [SerializeField]
        Camera _uiCamera;
        [SerializeField]
        RectTransform _canvasRect;
        [SerializeField]
        SpiritVesselHealthBar _healthBarTemplate;

        public void SpawnHealthbar(Character character)
        {
            var healthbar = Instantiate(_healthBarTemplate, _canvasRect);
            healthbar.Healthbars = this;
            healthbar.Character = character;
            healthbar.gameObject.SetActive(true);
        }

        public void UpdatePosition(SpiritVesselHealthBar healthbar, Character character)
        {
            var rt = healthbar.GetComponent<RectTransform>();
            rt.anchoredPosition = _uiCamera.WorldToScreenPoint(character.transform.position);
        }
    }
}
