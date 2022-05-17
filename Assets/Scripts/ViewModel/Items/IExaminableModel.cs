using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExaminableModel : IIdentifiable, IKeyHolder
{
    bool IsExamining { get; set; }
}
