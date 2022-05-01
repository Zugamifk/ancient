using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject
{
    public string Name;
    public string DisplayName;
    public string DateOfBirth;
    public string Biography;
    public string Address;
    public GameObject MapPrefab;
    public float MoveSpeed = 1;
    public int MaxHealth;
}
