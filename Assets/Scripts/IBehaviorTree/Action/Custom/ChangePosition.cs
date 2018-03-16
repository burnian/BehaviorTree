using System;
using System.Collections.Generic;
using UnityEngine;


namespace IBehaviorTree
{
    class ChangePosition : BaseNode
    {
        public ChangePosition(Vector3 pos)
        {
            _pos = pos;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            GameObject go = (GameObject)tick.target;
            if (go == null)
            {
                return NODE_STATE.ERROR;
            }

            go.transform.localPosition = _pos;

            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        Vector3 _pos;
    }
}
