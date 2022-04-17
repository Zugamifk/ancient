using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour, ISelectable
{
    MouseInputState ISelectable.Select(MouseInputState current)
    {
        throw new System.NotImplementedException();
    }
}
