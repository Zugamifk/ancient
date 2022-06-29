using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System.Linq;

namespace SpiritVessel.View
{
    public class SpiritVesselCharacterViewSpawner : MapViewCharacterSpawner
    {
        [SerializeField]
        SpiritHealthbars _healthBars;

        protected override IEnumerable<Guid> GetCharacterIds()
            => Game.Model.GetModel<ISpiritVesselModel>().Map.CharacterIds;

        protected override void SpawnedView(ICharacterModel model, Character view)
        {
            base.SpawnedView(model, view);

            _healthBars.SpawnHealthbar(view);
        }

        protected override void DestroyedView(Character view)
        {
            base.DestroyedView(view);

            var splatter = DataService.GetData<VfxCollection>().GetItem("BloodSplatter");
            var inst = Instantiate(splatter);
            inst.transform.parent = view.transform.parent;
            inst.transform.position = view.transform.position;
            inst.SetLayerRecursively(LayerMask.NameToLayer("SpiritVessel"));
        }
    }
}
