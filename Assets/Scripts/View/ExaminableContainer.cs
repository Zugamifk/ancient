using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableContainer : MonoBehaviour
{
    [SerializeField]
    Transform _examinableRoot;
    [SerializeField]
    Camera _camera;

    static Examinable _currentExaminable;
    static ExaminableContainer _instance;

    private void Awake()
    {
        _instance = this;
    }

    public static void SetExaminable(Examinable examinable)
    {
        if(_currentExaminable!=null)
        {
            ClearExaminable();
        }

        var root = examinable.ExaminableView;
        examinable.SetCamera(_instance._camera);
        root.transform.SetParent(_instance._examinableRoot);
        root.transform.localPosition = Vector3.zero;
        root.SetLayerRecursively(LayerMask.NameToLayer(Name.Camera.Examinables));
        root.SetActive(true);

        _currentExaminable = examinable;
    }

    public static void ClearExaminable()
    {
        _currentExaminable = null;
    }
}
