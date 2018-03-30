using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace IBehaviorTree
{
    class PlayAnimation : Action
    {
        public PlayAnimation(string animeName)
        {
            _animeName = animeName;
            _state = NODE_STATE.RUNNING;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            Agent agent = tick.agent as Agent;
            var animator = agent.GetComponent<Animator>();
            if (animator == null)
            {
                _state = NODE_STATE.ERROR;
                return;
            }

            //Action dispose = null;
            //dispose = EventManager.Instance.AddEventListener("PlayAnimation", (args) =>
            //{
            //    _state = NODE_STATE.SUCCESS;
            //    dispose();
            //});

            animator.Play(_animeName);

            _state = NODE_STATE.RUNNING;
        }

        override public NODE_STATE Tick(Tick tick)
        {
            return _state;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        protected string _animeName;
        protected NODE_STATE _state;
    }
}
