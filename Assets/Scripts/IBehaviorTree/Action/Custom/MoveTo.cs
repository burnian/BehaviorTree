using System;
using System.Collections.Generic;
using UnityEngine;


namespace IBehaviorTree
{
    class MoveTo : BaseNode
    {
        public MoveTo(Vector3 pos)
        {
            _des = pos;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            tick.blackboard.Set("startTime", DateTime.Now, tick.tree.id, id);
        }

        override public NODE_STATE Tick(Tick tick)
        {
            GameObject go = (GameObject)tick.target;
            if (go == null)
            {
                return NODE_STATE.ERROR;
            }

            var startTime = tick.blackboard.Get<DateTime>("startTime", tick.tree.id, id);
            double elapseTime = (DateTime.Now - startTime).TotalMilliseconds;
            tick.debug.Log("MoveTo", "startTime=" + startTime + " elapseTime=" + elapseTime);

            go.transform.localPosition = _pos;

            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        Vector3 _des;
    }
}
