using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExaminable : IIdentifiable, IKeyHolder
{
    bool IsExamining { get; set; }
}
