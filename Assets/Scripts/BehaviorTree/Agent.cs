using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    public class Agent
    {
        public virtual void SetColor(object color) { }
        public virtual void SetPosition(object pos) { }

        public virtual void DoSomething() { }
    }
}
