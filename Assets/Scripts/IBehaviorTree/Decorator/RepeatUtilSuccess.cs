using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class RepeatUtilSuccess : BaseNode
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            BaseNode child = children[0];

            if (child == null)
            {
                return NODE_STATE.ERROR;
            }

            var state = child.Execute(tick);
            return state == NODE_STATE.SUCCESS ? state : NODE_STATE.RUNNING;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }

    }
}
