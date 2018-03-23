using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    public class BehaviorTree
    {
        public BehaviorTree(BaseNode root)
        {
            this.id = Utils.CreateUUID();
            this.root = root;
        }

        public void tick(object agent, Blackboard blackboard, IDebugger debug)
        {
            var tick = new Tick(this, agent, blackboard, debug);

            // 把当前树的整个节点逻辑刷一遍
            root.Execute(tick);

            // 下面的所有代码做了一件事，把所有上一个 tick RUNNING 而当前 tick 没有 RUNNING 的节点再 Close 一遍。
            var lastOpenNodes = blackboard.Get<List<BaseNode>>("openNodes", id);
            var currOpenNodes = tick.openNodes;

            // does not close if it is still open in this tick
            int start = 0;
            for (int i = 0; i < Math.Min(lastOpenNodes.Count, currOpenNodes.Count); i++)
            {
                start = i + 1;
                if (lastOpenNodes[i] != currOpenNodes[i])
                {
                    break;
                }
            }

            // close the nodes
            // 从 lastOpenNodes 的最后一个节点 close 到 currOpenNodes 的最后一个节点索引+1处，如果上面检测到不相同的节点，则 close 到不相同节点索引+1处
            // 这里需要 Close 的每个节点，都有可能在当前 tick 中调用过自己的 Close 方法了，这里会重复调用一次
            for (int i = lastOpenNodes.Count - 1; i >= start; i--)
            {
                lastOpenNodes[i].Close(tick);
            }

            // 保存当前开启的节点
            blackboard.Set("openNodes", currOpenNodes, id);
        }


        public string id;
        public BaseNode root;
    }
}
