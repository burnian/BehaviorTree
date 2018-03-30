using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class Condition : Action
    {
        public Condition(Func<Tick, bool> func)
        {
            _func = func;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            return _func(tick) ? NODE_STATE.SUCCESS : NODE_STATE.FAILURE;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        Func<Tick, bool> _func;
    }
}
