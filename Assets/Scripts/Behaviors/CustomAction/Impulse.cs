using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace IBehaviorTree
{
    class Impulse : Action
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            //tick.blackboard.Set();

            //go.transform.localPosition = _pos;

            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }

    }
}
