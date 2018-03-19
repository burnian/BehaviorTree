using System.Collections.Generic;
using UnityEngine;
using Behaviors;


public class Agent : MonoBehaviour
{
    void Start()
    {
        HeroBehavior b = BehaviorManager.Instance.GetBehavior<HeroBehavior>();


        //transform.localPosition = Vector3.zero;
        //GetComponent<RectTransform>();
    }

    [HideInInspector]
    public BehaviorType behaviorType;
}
