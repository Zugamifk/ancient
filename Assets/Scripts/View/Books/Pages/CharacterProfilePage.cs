using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterProfilePage : Page<ICharacterProfilePageModel>
{
    [SerializeField]
    TextMeshPro _name;

    public override void SetPage(ICharacterProfilePageModel model)
    {
    }
}
