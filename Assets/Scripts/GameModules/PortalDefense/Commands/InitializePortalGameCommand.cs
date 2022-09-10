using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Model;

namespace PortalDefense.Commands
{
    public class InitializePortalGameCommand : CreateModelCommand<PortalDefenseModel>
    {
        protected override void OnCreatedModel(GameModel game, PortalDefenseModel model)
        {
            Game.Do(new GenerateMapCommand());
            Game.Do(new StartWaveCommand());
        }
    }
}
