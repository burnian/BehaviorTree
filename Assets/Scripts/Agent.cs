using System;
using UnityEngine;
using Behaviors;
using Races;
using Jobs;


public class Agent : MonoBehaviour
{
    void Start()
    {
        _radius = GetComponent<RectTransform>().rect.width / 2;
    }

    void Update()
    {
        if (behavior != null)
        {
            behavior.tree.tick(this, BehaviorManager.Instance.blackboard, Debugger.Instance);
        }

        if (attribute.health > 0)
        {
        }
    }

    public void SetBehavior<T>() where T : Behavior
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
            }
            return _attribute;
        }
    }


    public float _radius;
    public Behavior behavior;
    public Race race; // race.GetType() == typeof(Human)
    public Job job;

    bool _isDirty = true;
    Action _behaviorRecycleDelegate = () => { };
    //public Level level;
    //public Equipment equipment;
}
