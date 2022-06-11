using City.Model;
using Map.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Commands
{
    public class CityCommandFactory : MapCommandFactory
    {
        public CityCommandFactory() : base(new MutableCityMapHandle()) { }
    }
}
