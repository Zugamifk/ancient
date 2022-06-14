using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpiritVessel.View
{
    public class SpiritVesselDeskItem : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer _mainSealSprite;
        [SerializeField]
        SpriteRenderer[] _redSealSprites;
        [SerializeField]
        SpriteRenderer[] _whiteSealSprites;

        [SerializeField]
        string _mapSceneName;
        [SerializeField]
        string _mapRenderCameraName;
        [SerializeField]
        RawImage _mapRender;

        void Start()
        {
            SceneManager.LoadScene(_mapSceneName, LoadSceneMode.Additive);
            StartCoroutine(GetMapRender());
        }

        IEnumerator GetMapRender()
        {
            CameraController cameraController = null;
            yield return new WaitUntil(() => CameraController.TryGetCamera(_mapRenderCameraName, out cameraController));
            _mapRender.texture = cameraController.Camera.targetTexture;
        }
    }
}