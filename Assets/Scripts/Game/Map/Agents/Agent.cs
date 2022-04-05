using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; set; }

    public void FrameUpdate(IAgentModel model)
    {
        transform.position = model.WorldPosition;
    }
}
