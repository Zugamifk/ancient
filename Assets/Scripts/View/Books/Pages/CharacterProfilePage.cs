using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterProfilePage : Page<ICharacterProfilePageModel>
{
    [SerializeField]
    TextMeshProUGUI _name;
    [SerializeField]
    TextMeshProUGUI _dateOfBirth;
    [SerializeField]
    TextMeshProUGUI _address;
    [SerializeField]
    TextMeshProUGUI _biography;

    public override void SetPage(ICharacterProfilePageModel model)
    {
        _name.text = model.Name;
        _dateOfBirth.text = model.DateOfBirth;
        _address.text = model.Address;
        _biography.text = model.Biography;
    }
}
