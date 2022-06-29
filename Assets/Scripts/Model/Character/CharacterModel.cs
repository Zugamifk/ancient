using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterModel : ICharacterModel
{
    public string Key => Profile.Name;
    public Guid MapId { get; set; }
    public Guid Id { get; } = Guid.NewGuid();
    public ProfileModel Profile;
    public HealthModel Health = new();
    public Vector2 Position { get; set; }
    public bool IsVisibleOnMap { get; set; }

}
