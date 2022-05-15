using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]
[RequireComponent(typeof(Identifiable))]
public class PackageDeskItem : MonoBehaviour
{
    private void Start()
    {
        var clickable = GetComponent<Clickable>();
        clickable.Clicked += ClickAction;
    }

    void ClickAction(int button)
    {
        var identifiable = GetComponent<Identifiable>();
        Game.Do(new OpenPackageCommand(identifiable.Id));
    }
}
