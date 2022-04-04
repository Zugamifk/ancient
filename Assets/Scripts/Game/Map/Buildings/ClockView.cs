using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockView : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _clockSpriteRenderer;
    [SerializeField]
    Sprite[] _clockFaces;

    public void UpdateClock(int hour)
    {
        hour %= 12;
        _clockSpriteRenderer.sprite = _clockFaces[hour];
    }
}
