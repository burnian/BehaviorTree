﻿using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    // “与”操作，某节点执行失败才返回该节点状态，下次从 runningChild 记录的该节点开始执行
    class MemSequence : Composite
    {
        public MemSequence(IEnumerable<BaseNode> branch = null) : base(branch)
        {
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            //tick.debug.Log("MemSequence", "Open");
            tick.blackboard.Set("runningChild", 0, tick.tree.id, id);
        }

        override public NODE_STATE Tick(Tick tick)
        {
            var runningChild = tick.blackboard.Get<int>("runningChild", tick.tree.id, id);

            for (int i = runningChild; i < children.Count; i++)
            {
                NODE_STATE state = children[i].Execute(tick);
                if (state != NODE_STATE.SUCCESS)
                {
                    if (state == NODE_STATE.RUNNING)
                    {
                        tick.blackboard.Set("runningChild", i, tick.tree.id, id);
                    }
                    return state;
                }
            }
            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }
    }
}
