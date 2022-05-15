using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class Character : MonoBehaviour, IView<ICharacterModel>, IMapObject
{
    [SerializeField]
    Transform _view;

    Vector2 _positionOffset = Vector2.one;
    Identifiable _identifiable;

    ITileMapTransformer _tileMap;

    void IMapObject.SetTileMap(ITileMapTransformer tileMap)
    {
        _tileMap = tileMap;
    }

    private void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
        _positionOffset = new Vector2(0.5f - Random.value, .5f - Random.value);
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
            transform.position = _tileMap.ModelToWorld(characterModel.Position + _positionOffset);
            var currentPosition = transform.position;
            var dir = currentPosition - oldPosition;
            _view.transform.localRotation = Quaternion.Euler(0, dir.x < 0 ? 180 : 0, 0);
            gameObject.SetActive(characterModel.IsVisibleOnMap);
            Game.Do(new UpdateMovementCommand(_identifiable.Id));
        }
    }
}
