using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterModel : ICharacterModel
{
    public string Key => Profile.Name;
    public Guid Id { get; } = Guid.NewGuid();
    public ProfileModel Profile;
    public MovementModel Movement;
    public HealthModel Health = new HealthModel();

    #region ICharacterModel
    public Vector2 Position => Movement.WorldPosition;
    bool ICharacterModel.IsVisibleOnMap => Movement.IsVisibleOnMap;
    #endregion
}
