using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    public class Tick
    {
        public Tick(BehaviorTree tree, object target, Blackboard blackboard, IDebugger debug)
        {
            this.tree = tree;
            this.openNodes = new List<BaseNode>();
            this.target = target;
            this.blackboard = blackboard;
            this.debug = debug;
        }

        // 记录 RUNNING 的节点
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

        // 移除非 RUNNING 的节点
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


        public BehaviorTree tree;
        public List<BaseNode> openNodes;
        public IDebugger debug;
        public object target;
        public Blackboard blackboard;
    }
}
