using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIdentifiableLookup<out TIdentifiable>
    where TIdentifiable : IIdentifiable
{
    bool HasKey(string key);
    TIdentifiable GetItem(string key);
    IEnumerable<TIdentifiable> AllItems { get; }
}
