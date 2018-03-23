//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-19
/// Description: 消息收发管理器
//////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;


namespace Utils
{
    using Listener = List<AnyEvent>;

    public delegate void AnyEvent(params object[] args);


    // 消息管理器
    public class EventManager
    {
        public static EventManager Instance;
        public static void Init()
        {
            Instance = new EventManager();
        }

        public EventManager()
        {
            _listeners = new Dictionary<string, Listener>();
        }
        
        public Action AddEventListener(string eventName, AnyEvent func)
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

            // 这里之所以要ToArray 一下，是为了复制一份listener，而不是对源数据进行操作，因为func 可能修改listener 的长度。
            foreach (var func in listener.ToArray())
            {
                func(args);
            }
        }


        Dictionary<string, Listener> _listeners;
    }
}
