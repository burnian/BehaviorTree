using System;
using System.Collections.Generic;


namespace Utils
{
    using Listener = List<AnyDelegate>;


    public delegate void VoidDelegate();
    public delegate void AnyDelegate(params object[] args);


    // 消息管理器
    public class EventManager
    {
        public static void Init()
        {
            Instance = new EventManager();
        }

        public EventManager()
        {
            _listeners = new Dictionary<string, Listener>();
        }

        public VoidDelegate AddEventListener(string eventName, AnyDelegate func)
        {
            Listener listener = null;
            if (!_listeners.TryGetValue(eventName, out listener))
            {
                listener = new Listener();
                _listeners.Add(eventName, listener);
            }
            if (listener.IndexOf(func) < 0)
            {
                listener.Add(func);
            }

            return () =>
            {
                if (listener != null)
                {
                    listener.Remove(func);
                }
            };
        }

        public void RemoveEventListener(string eventName)
        {
            // 这里GC会去清空listener 中的delegate
            _listeners.Remove(eventName);
        }

        public void Clear()
        {
            _listeners.Clear();
        }

        public void DispatchEvent(string eventName, params object[] args)
        {
            Listener listener = null;
            if (!_listeners.TryGetValue(eventName, out listener))
            {
                return;
            }

            foreach (var func in listener.ToArray())
            {
                func(args);
            }
        }


        public static EventManager Instance;
        Dictionary<string, Listener> _listeners;
    }
}
