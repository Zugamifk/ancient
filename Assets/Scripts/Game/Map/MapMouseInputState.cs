using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMouseInput : MouseInputState
{
    Map _map;
    public MapMouseInput(MouseInputState state, Map map)
        : base(state)
    {
        _map = map;
    }

    public override MouseInputState UpdateState()
    {
        RaycastHit hit;
        if (_context.DeskCameraController.RayCast(Input.mousePosition, 1 << LayerMask.NameToLayer(Layers.Desk), out hit))
        {
            var target = hit.collider.gameObject;
            var renderTex = target.GetComponent<RenderTextureRaycaster>();
            if (renderTex != null)
            {
                if (renderTex.Raycast(hit.textureCoord, out hit))
                {
                    _map.SetTile(hit.point, Names.Tiles.Road);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            return new IdleMouseInputState(this);
        } else
        {
            return this;
        }
    }
}
