using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Commands
{
    public class MapCommandFactory
    {
        IMutableMapHandle _mapHandle;

        public MapCommandFactory(IMutableMapHandle mapHandle)
        {
            _mapHandle = mapHandle;
        }

        public TCommand GetCommand<TCommand>()
            where TCommand : ICommand, IMapModelMutator, new()
        {
            var cmd = new TCommand();
            cmd.SetMapHandle(_mapHandle);
            return cmd;
        }
    }
}
