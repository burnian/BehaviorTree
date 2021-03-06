﻿using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    // 把所有子节点的逻辑都执行一遍，统计成功数和失败数
    internal class Parallel : Composite
    {
        public Parallel(IEnumerable<BaseNode> children = null, int succCount = 0, int failCount = 0) : base(children)
        {
            _succCount = succCount;
            _failCount = failCount;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            int succCount = 0;
            int failCount = 0;
            foreach (BaseNode child in children)
            {
                NODE_STATE state = child.Execute(tick);
                if (state == NODE_STATE.SUCCESS)
                {
                    succCount++;
                }
                if (state == NODE_STATE.FAILURE)
                {
                    failCount++;
                }
            }
            if (succCount > _succCount)
            {
                return NODE_STATE.SUCCESS;
            }
            else if (failCount > _failCount)
            {
                return NODE_STATE.FAILURE;
            }
            else
            {
                return NODE_STATE.RUNNING;
            }
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        private int _succCount;
        private int _failCount;
    }
}
