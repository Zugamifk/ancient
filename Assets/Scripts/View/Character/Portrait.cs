using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portrait : MonoBehaviour
{
    [SerializeField]
    Image _head;
    [SerializeField]
    Image _eyes;
    [SerializeField]
    Image _nose;
    [SerializeField]
    Image _mouth;
    [SerializeField]
    Image _hair;
    [SerializeField]
    PortraitData _data;

    private void Start()
    {
        RandomizePortrait();
    }

    public void RandomizePortrait()
    {
        Sprite head, eyes, nose, mouth, hair;
        _data.GetRandomFace(out head, out eyes, out nose, out mouth, out hair);
        SetSprite(_head, head);
        SetSprite(_eyes, eyes);
        SetSprite(_nose, nose);
        SetSprite(_mouth, mouth);
        SetSprite(_hair, hair);
    }

    void SetSprite(Image image, Sprite sprite)
    {
        image.sprite = sprite;
        var tf = image.GetComponent<RectTransform>();
        tf.pivot = sprite.pivot / sprite.rect.size;
        tf.sizeDelta = sprite.rect.size / sprite.pixelsPerUnit;
    }
}
