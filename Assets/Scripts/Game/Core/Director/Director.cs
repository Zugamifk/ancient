using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director
{
    GameController _controller;
    NarrativeCollection _collection;
    List<Narrative> _activeNarratives = new List<Narrative>();

    public Director(NarrativeCollection collection, GameController controller)
    {
        _collection = collection;
        _controller = controller;
    }

    #region Life cycle
    public void FrameUpdate()
    {
        foreach (var n in _activeNarratives)
        {
            n.FrameUpdate(this, _controller.Model);
        }
    }
    #endregion

    #region Commands
    public void StartNarrative(string name)
    {
        var narrative = BuildNarrative(name);
        _activeNarratives.Add(narrative);
    }

    public void SpawnAgent(string name, string position)
    {
        var spawnPosition = ParsePosition(position);
        _controller.AddAgent(name, spawnPosition);
    }

    public void WalkToPosition(string name, string position)
    {
        var destination = ParsePosition(position);
        _controller.WalkToPosition(name, destination);
    }

    public void SetTile(int x, int y, string name)
    {
        _controller.SetTile(x, y, name);
    }
    #endregion

    #region Helpers
    Narrative BuildNarrative(string name)
    {
        return new Narrative(_collection.GetNarrative(name));
    }

    Vector2 ParsePosition(string position)
    {
        Vector2 spawnPosition;
        if (position.Contains(","))
        {
            var split = position.Split(",");
            spawnPosition = new Vector2Int(int.Parse(split[0].Trim()), int.Parse(split[0].Trim()));
        }
        else
        {
            var b = _controller.Model.Map.GetBuilding(position);
            spawnPosition = b.Position;
        }
        return spawnPosition;
    }
    #endregion
}
