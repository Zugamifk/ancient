using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PortalDefense.Commands;
using PortalDefense.ViewModel;
using MeshGenerator;
using PortalDefense.Services;

namespace PortalDefense.View
{
    public class PortalDefenseCard : PortalDefenseMeshGeneratorUser
    {
        [SerializeField] MeshFilter _meshFilter;

        private void Start()
        {
            AssignMesh<CardFrameMeshGenerator>(_meshFilter);
        }
    }
}
