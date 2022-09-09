using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Narrative.States
{
    public class ReceiveItemState : NarrativeState<ReceiveItemData>
    {
        public override string UpdateState(IGameModel model)
        {
            Game.Do(new GetItemCommand(Data.Item));
            return Data.Next;
        }
    }
}