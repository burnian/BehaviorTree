using System;
using System.Collections.Generic;


namespace BehaviorTree
{
    class ChangePosition : BaseNode
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            tick.target.x = Math.floor(Math.random() * 800);
            tick.target.y = Math.floor(Math.random() * 600);

            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }
    }
}
