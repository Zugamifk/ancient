using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Words.View
{
    public class SelectableWord : Graphic, IPointerClickHandler
    {
        Vector3[] _corners = new Vector3[4];

        public void SetCorners(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            _corners[0] = p0;
            _corners[1] = p1;
            _corners[2] = p2;
            _corners[3] = p3;
            SetVerticesDirty();
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            vh.AddVert(_corners[0], Color.white, new Vector2(0, 0));
            vh.AddVert(_corners[1], Color.white, new Vector2(0, 1));
            vh.AddVert(_corners[2], Color.white, new Vector2(1, 1));
            vh.AddVert(_corners[3], Color.white, new Vector2(1, 0));
            vh.AddTriangle(0, 1, 2);
            vh.AddTriangle(0, 2, 3);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("clicked");
        }

        private void OnDrawGizmos()
        {
            for(int i=0;i<4;i++)
            {
                Gizmos.DrawLine(_corners[i], _corners[(i + 1) % 4]);
            }
        }
    }
}
