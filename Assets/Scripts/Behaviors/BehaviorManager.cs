//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-19
/// Description: 行为实例管理器
//////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using IBehaviorTree;
using Utils;


namespace Behaviors
{
    public enum BehaviorType
    {
        Hero = 0,
        Monster,
        NPC,

        END
    }

    public class BehaviorManager
    {
        public static BehaviorManager Instance;
        public static void Init()
        {
            Instance = new BehaviorManager();
        }

        public BehaviorManager()
        {
            _blackboard = new Blackboard();
        }


        public Behavior GetBehavior(BehaviorType type)
        {
            return _behaviorPool.GetObject();
        }

        public void Update()
        {
            foreach(var tree in _behaviorTrees)
            {
                tree.tick(agent, _blackboard, Debugger.Instance);

            }
        }


        Blackboard _blackboard;

    }
}
