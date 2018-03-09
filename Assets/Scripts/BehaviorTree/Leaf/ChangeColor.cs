using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class ChangeColor : BaseNode
    {
        public ChangeColor(object color)
        {
            _color = color;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            //tick.debug.Log("ChangeColor", "Open");
        }

        override public NODE_STATE Tick(Tick tick)
        {
            tick.target.SetColor(_color);

            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        object _color;
    }
}
