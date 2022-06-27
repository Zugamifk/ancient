using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SpiritVessel.ViewModel;

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

        private void Update()
        {
            var model = Game.Model.GetModel<ISpiritVesselModel>();
            var xp = (float)model.Experience;
            var need = (float)model.ExperienceNeeded;
            var max = _whiteSealSprites.Length;
            var to = max * xp / need;
            for(int i = 0; i < max; i++)
            {
                _whiteSealSprites[i].enabled = i <= to;
            }
        }

        IEnumerator GetMapRender()
        {
            CameraController cameraController = null;
            yield return new WaitUntil(() => CameraController.TryGetCamera(_mapRenderCameraName, out cameraController));
            _mapRender.texture = cameraController.Camera.targetTexture;
        }
    }
}