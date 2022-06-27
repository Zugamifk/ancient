using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System;

namespace SpiritVessel.View
{
    public class CloudViewSpawner : MapViewSpawner<ILightningSkillCloudModel, Cloud>
    {
        protected override IEnumerable<ILightningSkillCloudModel> AllModels()
            => GetLookup().AllItems;

        protected override ILightningSkillCloudModel GetModel(Guid id)
            => GetLookup().GetItem(id);

        IIdentifiableLookup<ILightningSkillCloudModel> GetLookup() =>
            Game.Model.GetModel<ISpiritVesselModel>().LightningSkill.Clouds;
    }
}
