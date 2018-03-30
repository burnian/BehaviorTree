//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-19
/// Description: 行为实例管理器
//////////////////////////////////////////////////////////////////////////
using UnityEngine;
using IBehaviorTree;
using Utils;


namespace Behaviors
{
    public class BehaviorManager
    {
        public static BehaviorManager Instance;
        public static void Init()
        {
            Instance = new BehaviorManager();
        }

        public BehaviorManager()
        {
            blackboard = new Blackboard();
            // 所有新添加的行为都要在这里注册创建
            CreateBehaviorPool<Move>();
            CreateBehaviorPool<Attack>();
        }

        public T GetBehavior<T>() where T : Behavior
        {
            ISimpleObjectPool pool;
            if (!ISimpleObjectPool.dicPool.TryGetValue(typeof(T), out pool))
            {
                return null;
            }
            return ((SimpleObjectPool<T>)pool).GetObject();
        }

        public void RecycleBehavior<T>(T behavior) where T : Behavior
        {
            if (behavior == null)
            {
                return;
            }

            blackboard.Remove(behavior.tree.id);
            ISimpleObjectPool pool;
            if (ISimpleObjectPool.dicPool.TryGetValue(typeof(T), out pool))
            {
                ((SimpleObjectPool<T>)pool).RecycleObject(behavior);
            }
        }

        public void ShowAllPoolIdleCount()
        {
            foreach(var pair in ISimpleObjectPool.dicPool)
            {
                Debug.Log(pair.Key.Name + " pool idle num = " + pair.Value.GetIdleCount());
            }
        }

        void CreateBehaviorPool<T>(int count = 10) where T : new()
        {
            new SimpleObjectPool<T>(() => { return new T(); }, count, (T behavior) => { });
        }


        public Blackboard blackboard;
    }
}
