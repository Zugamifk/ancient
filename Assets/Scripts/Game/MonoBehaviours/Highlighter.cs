using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SpriteOutline))]
public class Highlighter : MonoBehaviour
{
    public bool IsHighlighted { get; private set; }

    SpriteOutline _outlineValue;
    SpriteOutline _outline => _outlineValue ??= GetComponent<SpriteOutline>();

    public void Highlight(bool highlighted)
    {
        IsHighlighted = highlighted;
        _outline.enabled = highlighted;
    }
}
