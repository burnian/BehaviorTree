using System;
using System.Collections.Generic;


namespace BehaviorTree
{
    abstract class BaseNode
    {
        public BaseNode(IEnumerable<BaseNode> branch = null)
        {
            id = Utils.CreateUUID();

            children = new List<BaseNode>();
            if (branch != null)
            {
                children.AddRange(branch);
            }
        }

        public void AddChild(BaseNode node)
        {
            children.Add(node);
        }

        //public void RemoveChild(BaseNode node)
        //{
        //    children.Remove(node);
        //}

        public NODE_STATE Execute(Tick tick)
        {
            // 聚焦
            _Enter(tick);

            // 开启
            bool isOpen = (bool)(tick.blackboard.Get("isOpen", tick.tree.id, id));
            if (!isOpen)
            {
                _Open(tick);
            }

            // 主逻辑
            NODE_STATE state = _Tick(tick);

            // 关闭
            if (state != NODE_STATE.RUNNING)
            {
                _Close(tick);
            }

            // 失焦
            _Exit(tick);

            return state;
        }

        private void _Enter(Tick tick)
        {
            tick.EnterNode(this);
            Enter(tick);
        }

        private void _Open(Tick tick)
        {
            tick.OpenNode(this);
            tick.blackboard.Set("isOpen", true, tick.tree.id, this.id);
            Open(tick);
        }

        private NODE_STATE _Tick(Tick tick)
        {
            tick.TickNode(this);
            return Tick(tick);
        }

        private void _Close(Tick tick)
        {
            tick.CloseNode(this);
            Close(tick);
        }

        private void _Exit(Tick tick)
        {
            tick.EnterNode(this);
            Exit(tick);
        }

        public abstract void Enter(Tick tick);
        public abstract void Open(Tick tick);
        public abstract NODE_STATE Tick(Tick tick);
        public abstract void Close(Tick tick);
        public abstract void Exit(Tick tick);


        public string id;
        public List<BaseNode> children;
    }
}
