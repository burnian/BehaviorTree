using UnityEngine;
using IBehaviorTree;
using Utils;


namespace Behaviors
{
    class Guard : Behavior
    {
        public Guard()
        {
            root = new Parallel(new BaseNode[] {
                new MemSequence(new BaseNode[] {
                    new ChangeColor(Color.yellow),
                    new Wait(500),
                    new ChangeColor(Color.white),
                    new Wait(500),
                    new Failer(),
                }),
                new Condition((Tick tick) => {
                    var agent = tick.agent as Agent;
                    foreach (var v in SceneManager.Instance.campAgents)
                    {
                        if (v.Key != agent.camp)
                        {
                            foreach(var enemy in v.Value)
                            {
                                var dis = (agent.transform.position - enemy.transform.position).sqrMagnitude;
                                if (dis <= agent.attribute.vision * agent.attribute.vision)
                                {
                                    tick.blackboard.Set("target", enemy, tick.tree.id);
                                    return true;
                                }
                            }
                        }
                    }
                    return false;
                }),
            });
        }
    }
}
