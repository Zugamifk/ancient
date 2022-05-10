using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseBuildTurretCommand : ICommand
{
    string _name;
    Vector2Int _position;
    public TurretDefenseBuildTurretCommand(string name, Vector2Int position)
    {
        _name = name;
        _position = position;
    }

    public void Execute(GameController controller)
    {
        var building = controller.MapController.AddBuilding(controller.Model.MapModel, _name, _position);

        var turret = new TurretModel()
        {
            Id = building.Id,
            AttackRadius = 3
        };
        controller.Model.TurretDefenseModel.Turrets.AddItem(turret);
    }
}
