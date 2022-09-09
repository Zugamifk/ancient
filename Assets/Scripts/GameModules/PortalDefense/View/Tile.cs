using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.View
{
    public class Tile : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer _renderer;
        [SerializeField]
        BoxCollider _collider;

        public void SetTile(ITileModel tile)
        {

        }
    }
}
