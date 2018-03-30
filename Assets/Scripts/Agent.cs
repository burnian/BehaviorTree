using System;
using UnityEngine;
using Behaviors;
using Races;
using Jobs;
using IBehaviorTree;
using Common;


public class Agent : MonoBehaviour
{
    void Awake()
    {
        //Debug.Log("Agent.name=" + name);
        _cachedRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (behavior != null)
        {
            behavior.tree.tick(this, BehaviorManager.Instance.blackboard, Debugger.Instance);
        }

        if (attribute.health > 0)
        {
        }
    }

    public void MoveTo(Vector3 pos)
    {
        SetBehavior();
    }

    public void SetBehavior(BehaviorTree tree)
    {
        _behaviorRecycleDelegate();
        behavior = BehaviorManager.Instance.GetBehavior<T>();
        _behaviorRecycleDelegate = () =>
        {
            if (behavior != null)
            {
                BehaviorManager.Instance.RecycleBehavior((T)behavior);
                behavior = null;
            }
        };
    }

    public void SetRace<T>()
    {
        _isDirty = true;
        race = (Race)Activator.CreateInstance(typeof(T));
    }

    public void SetJob<T>()
    {
        _isDirty = true;
        job = (Job)Activator.CreateInstance(typeof(T));
    }

    void OnDestroy()
    {
        _behaviorRecycleDelegate();
    }

    Attribute _attribute;
    public Attribute attribute
    {
        get
        {
            if (_isDirty)
            {
                _isDirty = false;
                if (race == null)
                {
                    race = new Race();
                }
                if (job == null)
                {
                    job = new Job();
                }
                _attribute = race.attribute + job.attribute;
                _cachedRb.mass = _attribute.mass;
                _cachedRb.drag = _attribute.drag;
            }
            return _attribute;
        }
    }


    public Behavior behavior;
    public Race race;
    public Job job;
    //public Level level;
    //public Equipment equipment;

    public Camp camp;

    Rigidbody2D _cachedRb;
    bool _isDirty = true;
    Action _behaviorRecycleDelegate = () => { };
}
