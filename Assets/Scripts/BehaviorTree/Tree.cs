using System;
using System.Collections.Generic;


namespace BehaviorTree
{
    class Tree
    {
        public Tree(BaseNode node)
        {
            id = Utils.CreateUUID();
            root = node;
        }

        public void tick(object target, Blackboard blackboard)
        {
            /* CREATE A TICK OBJECT */
            Tick tick = new Tick();
            tick.target = target;
            tick.blackboard = blackboard;
            tick.tree = this;

            /* TICK NODE */
            root.Execute(tick);

            /* CLOSE NODES FROM LAST TICK, IF NEEDED */
            List<BaseNode> lastOpenNodes = (List<BaseNode>)(blackboard.Get("openNodes", id));
            List<BaseNode> currOpenNodes = tick.openNodes;

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
            for (int i = lastOpenNodes.Count - 1; i >= start; i--)
            {
                lastOpenNodes[i].Close(tick);
            }

            /* POPULATE BLACKBOARD */
            blackboard.Set("openNodes", currOpenNodes, id);
        }


        public string id;
        public BaseNode root;
    }
}
