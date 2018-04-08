using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    public abstract class Composite : BaseNode
    {
        public Composite(IEnumerable<BaseNode> children = null) : base(children)
        {
        }
    }
}
