using UnityEngine;
using IBehaviorTree;
using Utils;


namespace Behaviors
{
    /// <summary>
    /// 外部通过修改树的"endPos"属性来移动agent
    /// </summary>
    class Move : Behavior
    {
        public Move()
        {
            var root = new Sequence(new BaseNode[] {
                new Condition((Tick tick) =>
                {
                    var agent = tick.agent as Agent;
                    var endPos = tick.blackboard.Get<Vector3>("endPos", tick.tree.id);
                    return (agent.transform.position - endPos).sqrMagnitude > 0.1;
                }),
                new PhysicalMove("endPos"),
            });
        }

        public void SetDestination(BehaviorTree tree, Vector3 pos)
        {
            BehaviorManager.Instance.blackboard.Set("endPos", pos, tree.id);
        }
    }
}
