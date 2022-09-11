using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;
using System;

namespace PortalDefense.Model
{
    public class EndPortalModel : ITileStructure
    {
        public string Key => "EndPortal";

        public Guid Id { get; } = Guid.NewGuid();
    }
}
