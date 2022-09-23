using Model;
using PortalDefense.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Commands
{
    public class MoveCameraCommand : ICommand
    {
        Vector2 _delta;
        public MoveCameraCommand(Vector2 delta) => _delta = delta;
        public void Execute(GameModel model)
        {
            var pdm = model.GetModel<PortalDefenseModel>();
            var moveDelta = Quaternion.Euler(0, 0, -pdm.Camera.Angle) * _delta;
            pdm.Camera.Position += (Vector2)moveDelta * pdm.Camera.MoveSpeed * model.TimeModel.LastDeltaTime;
        }
    }
}
