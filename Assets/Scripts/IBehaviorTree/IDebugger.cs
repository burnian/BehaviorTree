using System;
using System.Collections.Generic;


namespace IBehaviorTree
{
    public abstract class IDebugger
    {
        public IDebugger()
        {
            _isEnabled = true;
        }

        abstract public void EnableLog(bool flag);
        abstract public void BTLog(string message);
        abstract public void BTLog(string tag, string message);

        protected bool _isEnabled;
    }
}
