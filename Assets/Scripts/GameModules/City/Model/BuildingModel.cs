using City.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Model
{
    public class BuildingModel : ICityGraphNode, IBuildingModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Guid MapId { get; set; }
        public string Key { get; set; }
        public Vector2 Position { get; set; }
        public Vector2Int EntrancePosition { get; set; }

        public HashSet<string> Agents = new HashSet<string>();

        Vector2Int ICityGraphNode.Position => Vector2Int.FloorToInt(Position);
    }
}