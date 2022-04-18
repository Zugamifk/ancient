using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameInitializer
{
    void StartNarrative(string name);
    void AddBuilding(string name, Vector2Int position);
    void BuildRoad(string startName, string endName);
}
