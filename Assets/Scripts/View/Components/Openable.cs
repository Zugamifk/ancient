using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class Openable : MonoBehaviour
{
    [SerializeField]
    GameObject _openedRoot;
    [SerializeField]
    GameObject _closedRoot;
    [SerializeField]
    Clickable _openClickable;
    [SerializeField]
    Clickable _closedClickable;

    Identifiable _identifiable;

    private void Start()
    {
        _identifiable = GetComponent<Identifiable>();
        _closedClickable.Clicked += ClickedClosedClickable;
        _openClickable.Clicked += ClickedOpenClickable;
    }

    private void Update()
    {
        if (_identifiable.Id != Guid.Empty)
        {
            var item = Game.Model.AllIdentifiables.GetItem(_identifiable.Id);
            if (item is IIsOpen openable)
            {
                SetOpenedState(openable.IsOpen);
            } else
            {
                throw new InvalidOperationException($"Item {item} ({_identifiable.Id}) is not IIsOpen!");
            }
        }
    }

    void ClickedOpenClickable(int _)
    {
        Game.Do(new CloseItemCommand(_identifiable.Id));
    }

    void ClickedClosedClickable(int _)
    {
        Game.Do(new OpenItemCommand(_identifiable.Id));
    }

    void SetOpenedState(bool isOpened)
    {
        _openedRoot.SetActive(isOpened);
        _closedRoot.SetActive(!isOpened);
    }
}
