using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateableGameObjectRegistry : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _updateableReferences = new List<GameObject>();

    List<IUpdateable> _updateables = new List<IUpdateable>();
    public IEnumerable<IUpdateable> Updateables => _updateables;

    private void Start()
    {
        foreach(var updateable in _updateableReferences)
        {
            foreach(var component in updateable.GetComponents<IUpdateable>()) {
                _updateables.Add(component);
            }
        }    
    }
}
