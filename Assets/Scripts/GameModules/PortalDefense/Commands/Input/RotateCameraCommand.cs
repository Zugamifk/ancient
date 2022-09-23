using Model;
using PortalDefense.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Commands
{
    public class RotateCameraCommand : ICommand
    {
        float _delta;
        public RotateCameraCommand(float delta) => _delta = delta;

        public void Execute(GameModel model)
        {
            var pdm = model.GetModel<PortalDefenseModel>();
            pdm.Camera.Angle += _delta * pdm.Camera.RotateSpeed * model.TimeModel.LastDeltaTime;
        }
    }
}
