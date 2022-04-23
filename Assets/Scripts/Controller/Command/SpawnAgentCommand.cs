using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgentCommand : ICommand
{
    string _name;
    string _position;
    public SpawnAgentCommand(string name, string position)
    {
        _name = name;
        _position = position;
    }

    public void Execute(GameController controller)
    {
        var spawnPosition = controller.ParsePosition(_position);
        var data = controller.AgentCollection.GetAgent(_name);
        var agent = new AgentModel()
        {
            Name = _name,
            MoveSpeed = data.MoveSpeed,
            WorldPosition = spawnPosition
        };
        controller.Model.Agents.Add(_name, agent);
    }
}
