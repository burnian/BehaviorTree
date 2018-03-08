using System;
using System.Collections.Generic;


namespace BehaviorTree
{
    // 相当于“或”操作，所有节点都失败才返回失败，遇到非失败就返回
    class Priority : BaseNode
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            foreach (BaseNode child in children)
            {
                NODE_STATE state = child.Execute(tick);
                if (state != NODE_STATE.FAILURE)
                {
                    return state;
                }
            }
            return NODE_STATE.FAILURE;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }
    }
}
