using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using IBehaviorTree;


public class Debugger : IDebugger
{
    override public void EnableLog(bool flag)
    {
        _isEnabled = flag;
    }

    override public void Log(string message)
    {
        if (!_isEnabled)
        {
            return;
        }
        Debug.Log(message);
    }

    override public void Log(string tag, string message)
    {
        if (!_isEnabled)
        {
            return;
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("[");
        builder.Append(tag);
        builder.Append("] ");
        builder.Append(message);
        Debug.Log(builder);
    }
}
