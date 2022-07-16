using SpiritVessel.Model;
using SpiritVessel.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Data;

namespace SpiritVessel.Commands
{
    public class CreateSpiritVesselModelCommand : CreateModelCommand<SpiritVesselModel>
    {
        protected override void OnCreatedModel(GameModel game, SpiritVesselModel model)
        {
            Game.Do(new LoadMapDataCommand(model.MapModel.Id));
            Game.Do(new GenerateSpiritVesselMapCommand());
            InitializeGame(game, model);
        }

        void InitializeGame(GameModel game, SpiritVesselModel model)
        {
            model.OutsideRadius = 10;

            var progression = DataService.GetData<SpiritVesselProgressionData>();
            var levelData = progression.Levels[0];
            model.Level = 0;
            model.ExperienceNeeded = levelData.XpRequired;
            model.Experience = 0;

            Game.Do(new GainSkillCommand("Lightning"));
        }
    }
}
