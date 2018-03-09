using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    class PlayAnimation : BaseNode
    {
        public PlayAnimation(string animeName, bool isLoop = true)
        {
            _animeName = animeName;
            _isLoop = isLoop;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            //let skeleton = tick.target as sp.Skeleton;
            //this._running = true;
            //skeleton.setAnimation(0, this.animationName, this.loop);
            //skeleton.setEndListener(() =>
            //{
            //    this._running = false;
            //});
        }

        override public NODE_STATE Tick(Tick tick)
        {
            return _isRunning ? NODE_STATE.RUNNING : NODE_STATE.SUCCESS;
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        string _animeName;
        bool _isLoop;
        bool _isRunning;
    }
}
