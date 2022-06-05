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
    Clickable _clickable;

    Identifiable _identifiable;

    private void Start()
    {
        _identifiable = GetComponent<Identifiable>();
        _clickable.Clicked += Clicked;
    }

    private void Update()
    {
        var openable = Game.Model.AllIdentifiables.GetItem(_identifiable.Id) as IIsOpen;
        SetOpenedState(openable.IsOpen);
    }

    void Clicked(int button)
    {
        Game.Do(new OpenItemCommand(_identifiable.Id));
    }

    void SetOpenedState(bool isOpened)
    {
        _openedRoot.SetActive(isOpened);
        _closedRoot.SetActive(!isOpened);
    }
}
