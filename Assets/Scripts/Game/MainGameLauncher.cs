using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameLauncher : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("Desk", LoadSceneMode.Additive);
    }
}
