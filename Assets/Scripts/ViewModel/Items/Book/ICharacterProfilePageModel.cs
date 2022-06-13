using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterProfilePageModel : IPageModel
{
    public string Name { get; }
    public string DateOfBirth { get; }
    public string Address { get; }
    public string Biography { get; }
}
