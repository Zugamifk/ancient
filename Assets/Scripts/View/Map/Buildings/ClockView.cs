using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockView : MonoBehaviour
{
    [SerializeField]
    bool _continuous;
    [Header("Continuos")]
    [SerializeField]
    Transform _hourHand;
    [SerializeField]
    Transform _minuteHand;
    [Header("Frames")]
    [SerializeField]
    SpriteRenderer _clockSpriteRenderer;
    [SerializeField]
    Sprite[] _clockFaces;

    public void UpdateClock(ITimeModel model)
    {
        var minute = model.Minute;
        var hour = model.Hour;
        
        if(_continuous)
        {
            _hourHand.transform.localRotation = Quaternion.AngleAxis(360 * hour / 12, Vector3.forward);
            _minuteHand.transform.localRotation = Quaternion.AngleAxis(6 * minute, Vector3.forward);
        } else
        {
            hour %= 12;
            _clockSpriteRenderer.sprite = _clockFaces[hour];
        }
    }
}
