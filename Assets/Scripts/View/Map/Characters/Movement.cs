using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
[RequireComponent(typeof(MapPositionable))]
public class Movement : MonoBehaviour, IView<ICharacterModel>, IModelUpdateable
{
    [SerializeField]
    Transform _view;

    Identifiable _identifiable;

    private void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
    }

    private void Start()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    void IView<ICharacterModel>.InitializeFromModel(IGameModel gameModel, ICharacterModel model)
    {
        _identifiable.Id = model.Id;
    }

    void IModelUpdateable.UpdateFromModel(IGameModel model)
    {
        var characterModel = model.Characters.GetItem(_identifiable.Id);
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
