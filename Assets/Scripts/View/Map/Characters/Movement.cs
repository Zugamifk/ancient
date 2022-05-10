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
    MapPositionable _mapPositionable;

    Vector2 _positionOffset = Vector2.one;

    public Vector2 PositionOffset => _positionOffset;

    private void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
        _mapPositionable = GetComponent<MapPositionable>();
        _positionOffset = new Vector2(0.5f - Random.value, .5f - Random.value);
    }

    private void Start()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    void IView<ICharacterModel>.InitializeFromModel(ICharacterModel model)
    {
        _identifiable.Id = model.Id;
    }

    void IModelUpdateable.UpdateFromModel(IGameModel model)
    {
        var characterModel = model.Characters.GetItem(_identifiable.Id);
        if (characterModel != null)
        {
            var oldPosition = transform.position;
            _mapPositionable.UpdatePosition(characterModel.WorldPosition + PositionOffset);
            var currentPosition = transform.position;
            var dir = currentPosition - oldPosition;
            _view.transform.localRotation = Quaternion.Euler(0, dir.x < 0 ? 180 : 0, 0);
            gameObject.SetActive(characterModel.IsVisibleOnMap);
        }
    }
}
