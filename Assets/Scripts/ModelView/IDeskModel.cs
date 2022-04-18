using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeskModel 
{
    public IEnumerable<IDeskItemModel> Items { get; }
}
