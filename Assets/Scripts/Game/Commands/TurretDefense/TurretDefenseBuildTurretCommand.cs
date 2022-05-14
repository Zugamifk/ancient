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

    public void Execute(GameModel model)
    {
        var data = DataService.GetData<TurretDefenseData>().GetTurret(_name);
        var turretModel = new TurretModel();
        turretModel.Name = data.Name;
        turretModel.AttackRadius = data.Radius;
        turretModel.Position = _position;
        model.TurretDefenseModel.Turrets.AddItem(turretModel);
    }
}
