using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Commands;
using PortalDefense.ViewModel;
namespace PortalDefense.View
{
    public class PortalDefenseGame : MonoBehaviour
    {
        private void Start()
        {
            Game.Do(new InitializePortalGameCommand());
        }

        private void Update()
        {
            var model = Game.Model.GetModel<IPortalDefenseModel>();
            if (model.CurrentWave!=null)
            {
                Game.Do(new UpdateWaveCommand());
            }
        }
    }
}
