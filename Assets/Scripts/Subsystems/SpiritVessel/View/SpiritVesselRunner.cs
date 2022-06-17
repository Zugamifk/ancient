using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            _spawnTimer += Time.deltaTime;
            while (_spawnTimer > _spawnRate)
            {
                var pos  = _radius * Random.insideUnitCircle.normalized;
                Game.Do(new SpawnCharacterCommand()
                {
                    Name = "Kappa",
                    Position = pos
                });
                _spawnTimer -= _spawnRate;
            }
        }
    }
}
