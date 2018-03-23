using System.Collections;
using UnityEngine;
using Utils;
using Behaviors;


public class GameLogic : MonoBehaviour
{
    void Awake()
    {
        Debugger.Instance.EnableLog(false);

        InitModules();
    }

    void Update()
    {
        foreach(var v in Updatable.updatables)
        {
            v.Update();
        }
    }

    void InitModules()
    {
        EventManager.Init();
        Tween.Init();
        BehaviorManager.Init();
        SceneManager.Init();
    }

}
