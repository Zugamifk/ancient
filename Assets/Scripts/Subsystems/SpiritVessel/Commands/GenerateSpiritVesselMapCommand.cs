using SpiritVessel.Model;
using SpiritVessel.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Commands
{
    public class GenerateSpiritVesselMapCommand : ICommand
    {
        static PathGenerator _pathGenerator = new();
        public void Execute(GameModel model)
        {
            _pathGenerator.Generate(model.GetModel<SpiritVesselModel>().MapModel);
        }
    }
}
