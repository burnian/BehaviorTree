using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class Succeeder : BaseNode
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }
    }
}
