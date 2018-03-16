using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;


public class GameLogic : MonoBehaviour
{
    void Start()
    {
        InitModules();
    }

    // 初始化所有模块
    void InitModules()
    {
        EventManager.Init();
        Tween.Init();
        BTManager.Init();
    }
}
