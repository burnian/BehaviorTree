using System;
using System.Collections.Generic;


namespace BehaviorTree
{
    // 将 tick 时经过的时间与指定时长比较来决定返回的状态
    class Wait : BaseNode
    {
        public Wait(double milliseconds) : base()
        {
            _waitTime = milliseconds;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            tick.blackboard.Set("startTime", DateTime.Now, tick.tree.id, id);
        }

        override public NODE_STATE Tick(Tick tick)
        {
            DateTime startTime = (DateTime)(tick.blackboard.Get("startTime", tick.tree.id, id));
            double elapseTime = (DateTime.Now - startTime).TotalMilliseconds;
            if (elapseTime > _waitTime)
            {
                return NODE_STATE.SUCCESS;
            }
            return NODE_STATE.RUNNING;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        private double _waitTime;
    }
}
