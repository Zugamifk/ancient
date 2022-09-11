using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Commands;
using PortalDefense.ViewModel;
namespace PortalDefense.View
{
    public class PortalDefenseGame : MonoBehaviour
    {
        [SerializeField]
        Transform _spawnedRoot;

        public Transform SpawnRoot => _spawnedRoot;

        public static PortalDefenseGame Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

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
