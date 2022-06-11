using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Commands
{
    public class MapCommandFactory
    {
        Func<MapModel> _mapGetter;
        public MapCommandFactory(Func<MapModel> mapGetter)
        {
            _mapGetter = mapGetter;
        }

        public TCommand GetCommand<TCommand>()
            where TCommand : ICommand, IMapCommand, new()
        {
            var cmd = new TCommand();
            cmd.MapModel = _mapGetter.Invoke();
            return cmd;
        }
    }
}
