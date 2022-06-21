using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using SpiritVessel.Commands;

namespace SpiritVessel.View
{
    public class SpiritVesselRunner : MonoBehaviour
    {
        [SerializeField]
        float _radius;
        [SerializeField]
        float _spawnRate = 0.1f;

        float _spawnTimer = 0;

        private void Update()
        {
            var model = Game.Model.GetModel<ISpiritVesselModel>();
            _spawnTimer += Time.deltaTime;
            while (_spawnTimer > _spawnRate)
            {
                var pos  = _radius * Random.insideUnitCircle.normalized;
                Game.Do(new SpawnSpiritCommand("KappaSpirit", pos));
                Game.Do(new DoLightningStrikeCommand());
                _spawnTimer -= _spawnRate;
            }

            foreach(var id in model.Map.CharacterIds)
            {
                Game.Do(new UpdateSpiritCommand(id));
            }
        }
    }
}
