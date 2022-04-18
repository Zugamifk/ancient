using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureRaycaster : MonoBehaviour
{
    [SerializeField]
    Camera _camera;

    public bool RayCast(Vector2 texCoord, out RaycastHit hit)
    {
        // convert the hit texture coordinates into camera coordinates
        Ray portalRay = _camera.ScreenPointToRay(new Vector2(texCoord.x * _camera.pixelWidth, texCoord.y * _camera.pixelHeight));
        return Physics.Raycast(portalRay, out hit, float.MaxValue, 1 << LayerMask.NameToLayer(Layer.Map));
    }
}
