using City.Model;
using Map.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Commands
{
    public class CityCommandFactory : IMapCommandFactory
    {
        MapCommandFactory _mapCommandFactory = new(new MutableCityMapHandle());

        public TCommand GetCommand<TCommand>() 
            where TCommand : ICommand, IMapModelMutator, new()
        {
            return _mapCommandFactory.GetCommand<TCommand>();
        }
    }
}
