using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;


namespace IBehaviorTree
{
    public class Debugger : IDebugger
    {
        override public void EnableLog(bool flag)
        {
            _isEnabled = flag;
        }

        override public void Log(string message)
        {
            Debug.Log(message);
        }

        override public void Log(string tag, string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.Append(tag);
            builder.Append("] ");
            builder.Append(message);
            Debug.Log(builder);
        }
    }
}
