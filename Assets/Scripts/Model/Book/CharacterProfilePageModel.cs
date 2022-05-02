using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProfilePageModel : ICharacterProfilePageModel
{
    public string Name { get; set; }

    public string DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Biography { get; set; }
}
