using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a hack!!!! Find a better way!!!
public class UpdateableGameObjectRegistry : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _updateableReferences = new List<GameObject>();

    HashSet<IModelUpdateable> _updateables = new HashSet<IModelUpdateable>();
    public IEnumerable<IModelUpdateable> Updateables => _updateables;

    private void Start()
    {
        foreach(var updateable in _updateableReferences)
        {
            foreach(var component in updateable.GetComponents<IModelUpdateable>()) {
                _updateables.Add(component);
            }
        }    
    }
}
