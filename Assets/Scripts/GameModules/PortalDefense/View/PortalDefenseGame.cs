using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Commands;

namespace PortalDefense.View
{
    public class PortalDefenseGame : MonoBehaviour
    {
        private void Start()
        {
            Game.Do(new InitializePortalGameCommand());
        }
    }
}
