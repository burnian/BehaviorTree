using System;
using UnityEngine;
using IBehaviorTree;


namespace Behaviors
{
    class Patrol : Behavior
    {
        public Patrol()
        {
            root = new MemSequence(new BaseNode[] {
                new Condition((Tick tick) =>
                {
                    var center = tick.blackboard.Get<Vector3>("center", tick.tree.id, root.id);
                    var radius = tick.blackboard.Get<float>("radius", tick.tree.id, root.id);
                    var radian = BTUtils.RandomAgent.NextDouble() * 2 * Math.PI;
                    var distance = BTUtils.RandomAgent.NextDouble() * radius;
                    var x = distance * Math.Cos(radian);
                    var y = distance * Math.Sin(radian);
                    var endPos = new Vector3(center.x + (float)x, center.y + (float)y);
                    tick.blackboard.Set("endPos", endPos, tick.tree.id, root.id);
                    return true;
                }),
                new PhysicalMove("endPos"),
                new Wait(1000),
            });
        }

        public void SetPatrolCenter(BehaviorTree tree, Vector3 center)
        {
            BehaviorManager.Instance.blackboard.Set("center", center, tree.id, root.id);
        }

        public void SetPatrolRadius(BehaviorTree tree, float radius)
        {
            BehaviorManager.Instance.blackboard.Set("radius", radius, tree.id, root.id);
        }
    }
}
