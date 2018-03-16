using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class Repeater : BaseNode
    {
        public Repeater(int times)
        {
            _repeatTimes = times;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            tick.blackboard.Set("curTimes", 0, tick.tree.id, id);
        }

        override public NODE_STATE Tick(Tick tick)
        {
            BaseNode child = children[0];

            if (child == null)
            {
                return NODE_STATE.ERROR;
            }

            var curTimes = tick.blackboard.Get<int>("curTimes", tick.tree.id, id);
            if (curTimes >= _repeatTimes)
            {
                return NODE_STATE.SUCCESS;
            }
            if (child.Execute(tick) != NODE_STATE.RUNNING)
            {
                tick.blackboard.Set("curTimes", ++curTimes, tick.tree.id, id);
            }
            return NODE_STATE.RUNNING;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        int _repeatTimes;
    }
}
