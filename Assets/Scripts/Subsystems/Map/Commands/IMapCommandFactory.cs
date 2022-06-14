using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Commands
{
    public interface IMapCommandFactory
    {
        TCommand GetCommand<TCommand>()
            where TCommand : ICommand, IMapModelMutator, new();
    }
}
