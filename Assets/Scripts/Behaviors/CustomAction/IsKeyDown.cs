using System;
using System.Collections.Generic;
using UnityEngine;


namespace IBehaviorTree
{
    class IsKeyDown : Action
    {
        public IsKeyDown(KeyCode key)
        {
            _key = key;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            return Input.GetKeyDown(_key) ? NODE_STATE.SUCCESS : NODE_STATE.FAILURE;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        KeyCode _key;
    }
}
