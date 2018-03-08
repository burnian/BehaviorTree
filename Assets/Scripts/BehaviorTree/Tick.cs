using System;
using System.Collections.Generic;


namespace BehaviorTree
{
    class Tick
    {
        public Tick()
        {
            openNodes = new List<BaseNode>();
        }

        // 聚焦
        public void EnterNode(BaseNode node)
        {
            openNodes.Add(node);
            // call debug here
        }

        // 开启
        public void OpenNode(BaseNode node)
        {
            // call debug here
        }

        // 主逻辑
        public void TickNode(BaseNode node)
        {
            // call debug here
        }

        // 关闭
        public void CloseNode(BaseNode node)
        {
            // call debug here
            openNodes.Remove(node);
        }

        // 失焦
        public void ExitNode(BaseNode node)
        {
            // call debug here
        }


        public Tree tree;
        public List<BaseNode> openNodes;
        //public object debug;
        public object target;
        public Blackboard blackboard;
    }
}
