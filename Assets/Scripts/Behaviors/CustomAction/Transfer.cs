using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace IBehaviorTree
{
    class Transfer<T> : Action where T : Behaviors.Behavior
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            //(tick.agent as Agent).SetBehavior<T>();
        }

        override public NODE_STATE Tick(Tick tick)
        {
            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }

    }
}
