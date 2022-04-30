using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterModel : ICharacterModel
{
    public ProfileModel Profile;
    public MovementModel Movement;

    #region ICharacterModel
    string ICharacterModel.Name => Profile.Name;
    Vector2 ICharacterModel.WorldPosition => Movement.WorldPosition;
    bool ICharacterModel.IsVisibleOnMap => Movement.IsVisibleOnMap;
    #endregion
}
