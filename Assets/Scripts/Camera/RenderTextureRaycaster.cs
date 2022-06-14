using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureRaycaster : MonoBehaviour
{
    [SerializeField]
    string _cameraName;

    public bool RayCast(Vector2 texCoord, out RaycastHit hit)
    {
        hit = default;
        if (CameraController.TryGetCamera(_cameraName, out CameraController cc))
        {
            var cam = cc.Camera;
            Ray portalRay = cam.ScreenPointToRay(new Vector2(texCoord.x * cam.pixelWidth, texCoord.y * cam.pixelHeight));
            return Physics.Raycast(portalRay, out hit, float.MaxValue, 1 << LayerMask.NameToLayer(Layer.Map));
        } else
        {
            return false;
        }
    }
}
