using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; set; }
    [SerializeField]
    Transform _view;


    public void UpdateModel(IAgentModel model)
    {
        var dir = model.WorldPosition - (Vector2)transform.position;
        _view.transform.localRotation = Quaternion.Euler(0, dir.x < 0 ? 180 : 0, 0);
        transform.position = model.WorldPosition;
    }
}
