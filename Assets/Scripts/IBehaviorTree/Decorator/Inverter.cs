using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    // 将 action node 返回的状态取反
    class Inverter : Decorator
    {
        public Inverter(IEnumerable<BaseNode> children = null) : base(children) { }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            BaseNode child = children[0];

            if (child == null)
            {
                return NODE_STATE.ERROR;
            }

            NODE_STATE state = child.Execute(tick);

            if (state == NODE_STATE.SUCCESS)
            {
                state = NODE_STATE.FAILURE;
            }
            else if (state == NODE_STATE.FAILURE)
            {
                state = NODE_STATE.SUCCESS;
            }

            return state;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }
    }
}
