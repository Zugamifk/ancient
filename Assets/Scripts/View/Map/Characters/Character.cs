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
    ICharacterModel _model;
    public Vector2 ModelPosition => _model.Position;

    public Transform Root => transform;

    public bool UpdatesPosition => true;

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
            //var oldPosition = transform.position;

            //var currentPosition = transform.position;
            //var dir = currentPosition - oldPosition;
            //_view.transform.localRotation = Quaternion.Euler(0, dir.x < 0 ? 180 : 0, 0);
            gameObject.SetActive(characterModel.IsVisibleOnMap);
        }
    }
}
