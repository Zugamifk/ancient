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
            var healthbar = Instantiate(_healthBarTemplate);
            healthbar.Healthbars = this;
            healthbar.Character = character;
        }

        public void UpdatePosition(SpiritVesselHealthBar healthbar, Character character)
        {
            var rt = healthbar.GetComponent<RectTransform>();
            var vp = _uiCamera.WorldToScreenPoint(character.transform.position);
            vp.x *= _canvasRect.sizeDelta.x;
            vp.y *= _canvasRect.sizeDelta.y;
            vp.x -= _canvasRect.sizeDelta.x * _canvasRect.pivot.x;
            vp.y -= _canvasRect.sizeDelta.y * _canvasRect.pivot.y;
            healthbar.GetComponent<RectTransform>().anchoredPosition = vp;
        }
    }
}
