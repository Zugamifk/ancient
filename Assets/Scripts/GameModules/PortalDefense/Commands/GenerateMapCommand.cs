using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Services;
using PortalDefense.Model;
using Model;

namespace PortalDefense.Commands
{
    public class GenerateMapCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var generator = new MapGenerator();
            var portalGame = model.GetModel<PortalDefenseModel>();
            generator.GenerateMap(portalGame);
        }
    }
}
