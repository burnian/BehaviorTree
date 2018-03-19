using IBehaviorTree;
using Utils;


namespace Behaviors
{
    class HeroBehavior : Behavior
    {
        public static HeroBehavior Get()
        {
            _pool = new SimpleObjectPool<HeroBehavior>(GenerateTree, 5, DestroyTree);
            return 
        }

        HeroBehavior GenerateTree()
        {
            var obj = new HeroBehavior();
            var root = new MemSequence(new BaseNode[] {
                new Wait(5000),
            });
            obj.behaviorTree = new BehaviorTree(root);
            return obj;
        }

        private void DestroyTree(Behavior behavior)
        {

        }

        SimpleObjectPool<HeroBehavior> _pool;
    }
}
