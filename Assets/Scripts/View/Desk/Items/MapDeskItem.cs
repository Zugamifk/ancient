using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapDeskItem : MonoBehaviour
{
    [SerializeField]
    string _mapSceneName;

    void Start()
    {
        SceneManager.LoadScene(_mapSceneName, LoadSceneMode.Additive);
    }
}
