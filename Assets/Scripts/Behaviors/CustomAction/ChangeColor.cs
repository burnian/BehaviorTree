using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;


namespace IBehaviorTree
{
    class ChangeColor : Action
    {
        public ChangeColor(Color color)
        {
            _color = color;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick) { }

        override public NODE_STATE Tick(Tick tick)
        {
            (tick.agent as Agent).GetComponent<Image>().color = _color;

            return NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        Color _color;
    }
}
