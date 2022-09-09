using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.Model
{
    public class PortalDefenseModel : IPortalDefenseModel, IRegisteredModel
    {
        public MapModel Map { get; set; }

        IMapModel IPortalDefenseModel.Map => Map;
    }
}
