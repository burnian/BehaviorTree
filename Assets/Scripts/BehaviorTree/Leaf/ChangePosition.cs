using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class ChangePosition : BaseNode
    {
        public ChangePosition(object pos)
        {
            _pos = pos;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            //tick.debug.Log("ChangePosition", "Open");
        }

        override public NODE_STATE Tick(Tick tick)
        {
            tick.target.SetPosition(_pos);

            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }

        object _pos;
    }
}
