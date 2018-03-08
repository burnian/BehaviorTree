using System;
using System.Collections.Generic;


namespace BehaviorTree
{
    // “与”操作，所有 leaf node 都成功才返回成功，遇到非成功就返回
    class Sequence : BaseNode
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            foreach (BaseNode child in children)
            {
                NODE_STATE state = child.Execute(tick);
                if (state != NODE_STATE.SUCCESS)
                {
                    return state;
                }
            }
            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }
    }
}
