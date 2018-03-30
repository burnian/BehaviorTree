using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace IBehaviorTree
{
    class CommonMove : Action
    {
        /// <summary>
        /// <param name="key">保存在blackboard上的移动目标点的key</param>
        /// <param name="easeType">缓动函数</param>
        /// </summary>
        public CommonMove(string key, EASE easeType = EASE.Sin_In)
        {
            _key = key;
            _easeType = easeType;
        }

        override public void Enter(Tick tick) { }

        override public void Open(Tick tick)
        {
            Agent agent = tick.agent as Agent;
            _startPos = agent.transform.position;
            _updateCount = 0;
            Vector3 endPos = tick.blackboard.Get<Vector3>(_key, tick.tree.id);
            tick.debug.BTLog("MoveTo", "speed " + agent.attribute.moveSpeed);
            _endTime = (endPos - _startPos).magnitude / agent.attribute.moveSpeed;
        }

        override public NODE_STATE Tick(Tick tick)
        {
            Agent agent = tick.agent as Agent;
            if (agent == null)
            {
                return NODE_STATE.ERROR;
            }

            double time = _updateCount++ * Time.fixedDeltaTime * 1000;
            Vector3 endPos = tick.blackboard.Get<Vector3>(_key, tick.tree.id);
            // 因为_endTime 为0时不能做分母，所以这里判断需要使用 >= 而不是 >
            if (time >= _endTime)
            {
                agent.transform.position = endPos;
                return NODE_STATE.SUCCESS;
            }
            else
            {
                var fun = Tween.Instance.dicEaseToFunc[_easeType];
                Vector3 deltaVec = endPos - _startPos;
                double desX = fun(_startPos.x, deltaVec.x, time, _endTime);
                double desY = fun(_startPos.y, deltaVec.y, time, _endTime);
                double desZ = fun(_startPos.z, deltaVec.z, time, _endTime);

                agent.transform.position = new Vector3((float)desX, (float)desY, (float)desZ);
                return NODE_STATE.RUNNING;
            }
        }

        override public void Close(Tick tick) { }

        override public void Exit(Tick tick) { }


        uint _updateCount;
        Vector3 _startPos;
        string _key;
        double _endTime;
        EASE _easeType;
    }
}
