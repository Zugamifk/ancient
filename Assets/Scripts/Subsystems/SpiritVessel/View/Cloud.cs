using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.View
{
    [RequireComponent(typeof(Identifiable))]
    public class Cloud : MonoBehaviour, IView<ILightningSkillCloudModel>
    {
        Identifiable _identifiable;

        public void InitializeFromModel(ILightningSkillCloudModel model)
        {
            throw new System.NotImplementedException();
        }

        private void Start()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        void Update()
        {
            var model = Game.Model.GetModel<ISpiritVesselModel>().LightningSkill.Clouds.GetItem(_identifiable.Id);
        }
    }
}
