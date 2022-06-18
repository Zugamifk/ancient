using SpiritVessel.Model;
using SpiritVessel.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Commands
{
    public class CreateSpiritVesselModelCommand : CreateModelCommand<SpiritVesselModel>
    {
        protected override void OnCreatedModel(GameModel game, SpiritVesselModel model)
        {
            Game.Do(new LoadMapDataCommand(model.MapModel.Id));
            Game.Do(new GenerateSpiritVesselMapCommand());
        }
    }
}
