using System.Text;
using UnityEngine;
using IBehaviorTree;


public class Debugger : IDebugger
{
    private static Debugger _Instance;
    public static Debugger Instance
    {
        get
        {
            if (null == _Instance)
            {
                _Instance = new Debugger();
            }
            return _Instance;
        }
    }

    public static void Log(string message)
    {
        Instance.BTLog(message);
    }

    public static void Log(string tag, string message)
    {
        Instance.BTLog(tag, message);
    }

    override public void EnableLog(bool flag)
    {
        _isEnabled = flag;
    }

    override public void BTLog(string message)
    {
        if (!_isEnabled)
        {
            return;
        }
        Debug.Log(message);
    }

    override public void BTLog(string tag, string message)
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
