using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConnectable<TPart> where TPart : IConnectable<TPart>
{
    ISet<TPart> Connected { get; }
}
