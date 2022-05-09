using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurretDefenseBook : MonoBehaviour, IModelUpdateable
{
    const string k_LivesTextString = "LIVES: {0}/{1}";
    const string k_WaveCountTextString = "WAVE {0}";
    const string k_TimeTextString = "TIME: {0}";

    [SerializeField]
    TextMeshProUGUI _livesText;
    [SerializeField]
    TextMeshProUGUI _waveCountText;
    [SerializeField]
    TextMeshProUGUI _timeText;
    [SerializeField]
    string[] _buildingOptions;
    Action<string> _startBuildingAction;

    void Awake()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    public void UpdateFromModel(IGameModel model)
    {
        var tdModel = model.TurretDefense;
        _livesText.text = string.Format(k_LivesTextString, tdModel.Lives, tdModel.MaxLives);
        _waveCountText.text = string.Format(k_WaveCountTextString, tdModel.CurrentWave+1);
        _timeText.text = string.Format(k_TimeTextString, tdModel.CurrentTime.ToString(@"mm\:ss"));

        _startBuildingAction = tdModel.OnStartPlacingBuilding;
    }

    public void ClickedBuildOption(int index)
    {
        Debug.Log("Clicked");
        _startBuildingAction?.Invoke(_buildingOptions[index]);
    }
}