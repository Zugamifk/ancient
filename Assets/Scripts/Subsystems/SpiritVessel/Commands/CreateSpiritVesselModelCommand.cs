using SpiritVessel.Model;
using SpiritVessel.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Commands
{
    public class CreateSpiritVesselModelCommand : CreateModelCommand<SpiritVesselModel>
    {
        new public void Execute(GameModel model)
        {
            base.Execute(model);
            Game.Do(new LoadMapDataCommand(Game.Model.GetModel<ISpiritVesselModel>().Map.Id));
            Game.Do(new GenerateSpiritVesselMapCommand());
        }
    }
}
