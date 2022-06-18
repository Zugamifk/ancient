using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIdentifiableLookup<out TIdentifiable>
    where TIdentifiable : IIdentifiable
{
    TIdentifiable this[Guid id] { get; }
    bool HasUniqueName(string key);
    bool HasId(Guid id);
    TIdentifiable GetItem(string key);
    TIdentifiable GetItem(Guid id);
    IEnumerable<TIdentifiable> AllItems { get; }
}
