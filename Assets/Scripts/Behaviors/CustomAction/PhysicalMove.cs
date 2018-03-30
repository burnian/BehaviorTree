using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace IBehaviorTree
{
    class PhysicalMove : Action
    {
        /// <summary>
        /// <param name="key">保存在blackboard上的移动目标点的key</param>
        /// </summary>
        public PhysicalMove(string key)
        {
            _key = key;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            _cachedAgent = tick.agent as Agent;
            if (_cachedAgent == null)
            {
                return;
            }
            _cachedRb = _cachedAgent.GetComponent<Rigidbody2D>();
            var endPos = tick.blackboard.Get<Vector3>(_key, tick.tree.id);
            _lastVec = endPos - _cachedAgent.transform.position;
        }

        override public NODE_STATE Tick(Tick tick)
        {
            if (_cachedAgent == null)
            {
                return NODE_STATE.ERROR;
            }
            
            var endPos = tick.blackboard.Get<Vector3>(_key, tick.tree.id);
            tick.debug.BTLog("MoveTo", "speed " + _cachedAgent.attribute.moveSpeed);
            var curVec = endPos - _cachedAgent.transform.position;
            if (Vector3.Dot(curVec, _lastVec) <= 0)
            {
                _cachedAgent.transform.position = endPos;
                _cachedRb.velocity = Vector2.zero;
                return NODE_STATE.SUCCESS;
            }
            else
            {
                _cachedRb.velocity = curVec.normalized * _cachedAgent.attribute.moveSpeed;
                _lastVec = curVec;
                return NODE_STATE.RUNNING;
            }
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        Vector3 _lastVec;
        Agent _cachedAgent;
        Rigidbody2D _cachedRb;
        string _key;
    }
}
