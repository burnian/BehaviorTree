using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class IsMouseOver : BaseNode
    {
        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            //tick.debug.Log("IsMouseOver", "Open");
        }

        override public NODE_STATE Tick(Tick tick)
        {
            //var point = tick.target.globalToLocal(stage.mouseX, stage.mouseY);
            //if (tick.target.hitTest(point.x, point.y))
            //{
            //    return NODE_STATE.SUCCESS;
            //}
            //else
            //{
            return NODE_STATE.FAILURE;
            //}
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }
    }
}
