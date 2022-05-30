using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberRoll : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;
    [SerializeField]
    AnimationCurve _rollCurve;
    [SerializeField]
    float _rollTime;

    string _textFormat;
    float _rollProgress;
    int _lastValue;
    int _targetValue;
    int _displayedValue;

    void Update()
    {
        if (_displayedValue != _targetValue)
        {
            _rollProgress += Time.deltaTime / _rollTime;
            _rollProgress = Mathf.Clamp01(_rollProgress);
            var t = _rollCurve.Evaluate(_rollProgress);
            var newValue = Mathf.FloorToInt(Mathf.Lerp(_lastValue, _targetValue, t));
            if( newValue != _displayedValue)
            {
                _displayedValue = newValue;
                _text.text = string.Format(_textFormat, newValue);
            }
        }
    }

    public void SetTextFormat(string format)
    {
        _textFormat = format;
    }

    public void SetTarget(int target)
    {
        _rollProgress = 0;
        _lastValue = _displayedValue;
        _targetValue = target;
    }
}
