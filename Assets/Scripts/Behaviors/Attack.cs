using UnityEngine;
using IBehaviorTree;
using Utils;


namespace Behaviors
{
    class Attack : Behavior
    {
        public Attack()
        {
            root = new Parallel(new BaseNode[] {
                new MemSequence(new BaseNode[] {
                    new ChangeColor(Color.red),
                    new Wait(500),
                    new ChangeColor(Color.white),
                    new Wait(500),
                    new Failer(),
                }),
                new Sequence(new BaseNode[] {
                    new Condition((Tick tick)=>{
                        var target = tick.blackboard.Get<Agent>("target", tick.tree.id);
                        if (target != null)
                        {
                            tick.blackboard.Set("endPos", target.transform.position, tick.tree.id);
                            return true;
                        }
                        return false;
                    }),
                    new PhysicalMove("endPos"),
                }),
            });
        }

        public void SetTarget(BehaviorTree tree, Agent agent)
        {
            BehaviorManager.Instance.blackboard.Set("target", agent, tree.id, root.id);
        }
    }
}
