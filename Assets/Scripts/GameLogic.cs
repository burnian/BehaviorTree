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

    // 每个渲染帧更新，deltaTime不定
    void Update()
    {
        foreach(var v in Updatable.updatables)
        {
            v.Update();
        }
    }

    // 定帧更新，deltaTime恒定
    void FixedUpdate()
    {
        foreach (var v in Updatable.updatables)
        {
            v.FixedUpdate();
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
