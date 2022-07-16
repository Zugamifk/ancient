using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.View
{
    public class SpiritVesselAttackViewSpawner : MapViewSpawner<IAttackModel, Attack>
    {
        protected override IEnumerable<IAttackModel> AllModels() => Game.Model.GetModel<ISpiritVesselModel>().Attacks.AllItems;

        protected override IAttackModel GetModel(Guid id) => Game.Model.GetModel<ISpiritVesselModel>().Attacks.GetItem(id);

        protected override void SpawnedView(IAttackModel model, Attack view)
        {
            base.SpawnedView(model, view);
        }
    }
}
