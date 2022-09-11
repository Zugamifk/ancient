using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;
using PortalDefense.Services;
namespace PortalDefense.View
{
    public class PortalDefenseTile : MonoBehaviour
    {
        [SerializeField]
        MeshFilter _meshFilter;
        [SerializeField]
        BoxCollider _collider;
        [SerializeField]
        Transform _structureRoot;

        GameObject _currentStructure;

        public void SetTile(ITileModel tile, MapMeshGenerator.TileContext context)
        {
            UpdateTileGeometry(tile, context);
            if(tile.Structure!=null)
            {
                UpdateTileStructure(tile);
            }
        }

        void UpdateTileGeometry(ITileModel tile, MapMeshGenerator.TileContext context)
        {
            var meshGen = new MapMeshGenerator();
            var mesh = meshGen.GenerateTileMesh(tile, context);
            _meshFilter.mesh = mesh;

            _collider.center = new Vector3(0, tile.Height / 2f, 0);
            _collider.size = new Vector3(1, tile.Height, 1);
            _structureRoot.localPosition = new Vector3(0, tile.Height, 0);
        }

        void UpdateTileStructure(ITileModel tile)
        {
            if(_currentStructure!=null)
            {
                Destroy(_currentStructure);
            }

            var structure = Prefabs.GetInstance(tile.Structure);
            structure.transform.SetParent(_structureRoot);
            structure.transform.localPosition = Vector3.zero;

            var id = structure.GetComponent<Identifiable>();
            id.Id = tile.Structure.Id;

            _currentStructure = structure;
        }
    }
}
