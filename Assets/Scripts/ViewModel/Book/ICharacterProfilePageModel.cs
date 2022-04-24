using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterProfilePageModel : IPageModel
{
    public string Name { get; }
    public Sprite Portrait { get; }
}
