using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
[RequireComponent(typeof(MapPositionable))]
public class Character : MonoBehaviour, IView<ICharacterModel>
{
    [SerializeField]
    Transform _view;

    Identifiable _identifiable;

    private void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
    }

    void IView<ICharacterModel>.InitializeFromModel(ICharacterModel model)
    {
        _identifiable.Id = model.Id;
    }

    void Update()
    {
        var characterModel = Game.Model.Characters.GetItem(_identifiable.Id);
        if (characterModel != null)
        {
            var oldPosition = transform.position;
            var currentPosition = transform.position;
            var dir = currentPosition - oldPosition;
            _view.transform.localRotation = Quaternion.Euler(0, dir.x < 0 ? 180 : 0, 0);
            gameObject.SetActive(characterModel.IsVisibleOnMap);
        }
    }
}
