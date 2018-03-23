//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-19
/// Description: 泛型对象池
//////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;


namespace Utils
{
    public abstract class ISimpleObjectPool
    {
        // 这就意味着元素类型和元素池是一一对应的
        public static Dictionary<Type, ISimpleObjectPool> dicPool = new Dictionary<Type, ISimpleObjectPool>();

        public abstract void Release();
        public abstract int GetIdleCount();
        public abstract void CreateImmediate(uint uCreateNum);
        public abstract IEnumerator CreateInCoroutine(uint uCreateNum, uint uNumPerFrame = 0);
    }

    public class SimpleObjectPool<T> : ISimpleObjectPool
    {
        /// <summary>
        /// 构造，如果objectGenerator就只返回new Object()
        /// </summary>
        /// <param name="objectGenerator">构造方法</param>
        /// <param name="maxCount">对象池最大数量</param>
        /// <param name="objectDestroy">销毁方法</param>
        public SimpleObjectPool(Func<T> objectGenerator, int maxCount, Action<T> objectDestroyer)
        {
            dicPool[typeof(T)] = this;
            _objectGenerator = objectGenerator;
            _maxCount = maxCount;
            _objectDestroyer = objectDestroyer;
            _idleObjects = new Queue<T>();
        }

        /// <summary>
        /// 清空当前的对象池
        /// </summary>
        public override void Release()
        {
            while (_idleObjects.Count > 0)
            {
                DestroyObject(_idleObjects.Dequeue());
            }
        }

        /// <summary>
        /// 池子放不下了，要销毁对象
        /// </summary>
        public void DestroyObject(T obj)
        {
            if (null != _objectDestroyer)
            {
                _objectDestroyer(obj);
            }
        }

        /// <summary>
        /// 获取空闲状态下的对象数量
        /// </summary>
        public override int GetIdleCount()
        {
            return _idleObjects.Count;
        }


        /// <summary>
        /// 一帧直接创建某个数量的对象丢内存池里
        /// </summary>
        /// <param name="uCreateNum"></param>
        public override void CreateImmediate(uint uCreateNum)
        {
            for (int i = 0; i < uCreateNum; ++i)
            {
                RecycleObject(Generator());
            }
        }

        /// <summary>
        /// 如果想分帧创建所有对象，可用StartCoroutine来开启此方法
        /// </summary>
        /// <param name="uCreateNum">创建的数量</param>
        /// <param name="uNumPerFrame">每帧创建的个数，0代表一帧完成</param>
        public override IEnumerator CreateInCoroutine(uint uCreateNum, uint uNumPerFrame = 0)
        {
            if (0 == uNumPerFrame)
            {
                CreateImmediate(uCreateNum);
            }
            else
            {
                for (int i = 0; i < uCreateNum; ++i)
                {
                    RecycleObject(Generator());

                    //每隔一定的数量，停一下
                    if (0 == i % uNumPerFrame)
                    {
                        yield return null;
                    }
                }
            }

            yield break;
        }

        /// <summary>
        /// 获得一个对象，如果没有对象了，会调用objectGenerator委托返回一个对象，因此委托不能为null
        /// </summary>
        public virtual T GetObject()
        {
            T obj;
            if (0 == _idleObjects.Count)
            {
                obj = Generator();
            }
            else
            {
                obj = _idleObjects.Dequeue();
            }

            return obj;
        }

        /// <summary>
        /// 回收对象，回收前的清理工作，请调用者自己完成
        /// </summary>
        /// <param name="item"></param>
        public virtual void RecycleObject(T item)
        {
            if (null == item)
            {
                return;
            }
#if UNITY_EDITOR
            //先加个判断日志，有可能会有重复RecycleObject的，后续流程都没问题就删掉吧//
            if (_idleObjects.Contains(item))
            {
                Debugger.Log("SimpleObjectPool:RecycleObject->Repeat same item. " + item.ToString());
                return;
            }
#endif

            if (_idleObjects.Count >= _maxCount) //超过上限就销毁掉//
            {
                DestroyObject(item);
            }
            else
            {
                _idleObjects.Enqueue(item);
            }
        }

        /// <summary>
        /// 创建T实例，如果有传构造用的方法则用构造的
        /// </summary>
        protected virtual T Generator()
        {
            return _objectGenerator();
        }


        /// <summary>
        /// 空闲的对象, 为了支持可删除任意位置的，可改用list
        /// </summary>
        protected Queue<T> _idleObjects;
        /// <summary>
        /// 对象池的创建方法委托，返回T类型，无参
        /// </summary>
        private Func<T> _objectGenerator;
        /// <summary>
        /// 最大数量
        /// </summary>
        private int _maxCount;
        /// <summary>
        /// 对象销毁方法
        /// </summary>
        private Action<T> _objectDestroyer;
    }
}
