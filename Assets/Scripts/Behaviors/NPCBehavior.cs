using IBehaviorTree;
using Utils;


namespace Behaviors
{
    class NPCBehavior : Behavior
    {
        public NPCBehavior()
        {
            type = BEHAVIOR_TYPE.None;

            var root = new MemSequence(new BaseNode[] {
                new Wait(5000),
            });
            tree = new BehaviorTree(root);
        }
    }
}
