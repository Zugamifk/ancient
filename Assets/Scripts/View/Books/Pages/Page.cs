using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
}

public abstract class Page<TModel> : Page where TModel : IPageModel
{
    public abstract void SetPage(TModel model);
}
