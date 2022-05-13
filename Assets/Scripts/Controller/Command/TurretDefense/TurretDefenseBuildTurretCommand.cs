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
        var turret = controller.TurretDefenseController.GetNewTurretModel(_name);
        turret.Position = _position;
        controller.Model.TurretDefenseModel.Turrets.AddItem(turret);
    }
}
