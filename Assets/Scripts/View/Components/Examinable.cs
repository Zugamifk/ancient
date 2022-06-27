using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class Examinable : MonoBehaviour
{
    [SerializeField]
    GameObject _examinableRoot;
    [SerializeField]
    GameObject _deskItemRoot;
    [SerializeField]
    Clickable _deskItemClickable;
    [SerializeField]
    Canvas _examinableCanvas;

    Identifiable _identifiable;
    bool _isExamining;

    public GameObject ExaminableView => _examinableRoot;
    public bool IsExamining => _isExamining;

    public void SetCamera(Camera camera)
    {
        _examinableCanvas.worldCamera = camera;
    }

    private void Start()
    {
        _identifiable = GetComponent<Identifiable>();
        _deskItemClickable.Clicked += ClickedClosedClickable;
        _examinableRoot.SetActive(false);
        _deskItemRoot.SetActive(true);
    }

    private void Update()
    {
        if (_identifiable.Id != Guid.Empty)
        {
            var item = Game.Model.AllIdentifiables.GetItem(_identifiable.Id);
            if (item is IIsExamining examinable)
            {
                if (_isExamining != examinable.IsExamining)
                {
                    SetExaminingState(examinable.IsExamining);
                }
            }
            else
            {
                throw new InvalidOperationException($"Item {this} ({item} - {_identifiable.Id}) is not IIsExamining!");
            }
        }
    }

    void ClickedClosedClickable(int _)
    {
        Game.Do(new ExamineItemCommand(_identifiable.Id));
    }

    public void SetExaminingEvent(bool examining)
    {
        if (examining)
        {
            Game.Do(new ExamineItemCommand(_identifiable.Id));
        } else
        {
            Game.Do(new StopExaminingItemCommand(_identifiable.Id));
        }
    }

    void SetExaminingState(bool isExamining)
    {
        _isExamining = isExamining;
        _deskItemRoot.SetActive(!isExamining);
        _examinableRoot.SetActive(isExamining);

        if (isExamining)
        {
            ExaminableContainer.SetExaminable(this);
        }
    }
}
