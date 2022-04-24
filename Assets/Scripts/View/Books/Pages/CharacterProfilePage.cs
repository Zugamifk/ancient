using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterProfilePage : Page<ICharacterProfilePageModel>
{
    [SerializeField]
    TextMeshPro _name;
    [SerializeField]
    Image _portrait;

    public override void SetPage(ICharacterProfilePageModel model)
    {
        _portrait.sprite = model.Portrait;
    }
}
