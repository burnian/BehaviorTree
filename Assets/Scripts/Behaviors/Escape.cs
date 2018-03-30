using UnityEngine;
using IBehaviorTree;
using Utils;


namespace Behaviors
{
    class Escape : Behavior
    {
        public Escape()
        {
            var root = new MemSequence(new BaseNode[] {
                new Wait(1000),
            });
        }
    }
}
