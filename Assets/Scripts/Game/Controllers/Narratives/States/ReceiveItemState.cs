using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItemState : NarrativeState<ReceiveItemData>
{
    public override string UpdateState(IGameModel model)
    {
        EventHandler.SpawnDeskItem(Data.Item);
        return Data.Next;
    }
}
