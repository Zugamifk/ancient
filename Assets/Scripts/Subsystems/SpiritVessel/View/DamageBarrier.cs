using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Commands;

namespace SpiritVessel.View
{
    public class DamageBarrier : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spirit = collision.gameObject.GetComponent<Spirit>();
            if (spirit != null)
            {
                Game.Do(new KillSpiritCommand(spirit.Id));
            }
        }
    }
}
