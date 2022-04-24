using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitData : ScriptableObject
{
    public Sprite[] Heads;
    public Sprite[] Eyes;
    public Sprite[] Noses;
    public Sprite[] Mouths;
    public Sprite[] Hair;

    public void GetRandomFace(out Sprite head, out Sprite eyes, out Sprite nose, out Sprite mouth, out Sprite hair)
    {
        head = GetRandom(Heads);
        eyes = GetRandom(Eyes);
        nose = GetRandom(Noses);
        mouth = GetRandom(Mouths);
        hair = GetRandom(Hair);
    }

    Sprite GetRandom(Sprite[] sprites)
    {
        return sprites[Random.Range(0, sprites.Length)];
    }
}
