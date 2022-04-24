using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterProfilePage : Page<ICharacterProfilePageModel>
{
    [SerializeField]
    Image _portrait;

    public override void SetPage(ICharacterProfilePageModel model)
    {
        _portrait.sprite = model.Portrait;
    }
}
