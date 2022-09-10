using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;
using PortalDefense.Services;
namespace PortalDefense.View
{
    public class PortalGameTile : MonoBehaviour
    {
        [SerializeField]
        MeshFilter _meshFilter;
        [SerializeField]
        BoxCollider _collider;

        public void SetTile(ITileModel tile)
        {
            var meshGen = new MapMeshGenerator();
            var mesh = meshGen.GenerateTileMesh(tile);
            _meshFilter.mesh = mesh;

            _collider.center = new Vector3(0, tile.Height / 2, 0);
            _collider.size = new Vector3(1, tile.Height, 1);
        }
    }
}
