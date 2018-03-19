using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Behaviors;


public class GameLogic : MonoBehaviour
{
    void Start()
    {
        InitModules();

        DoLogic();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left
        {
            Debug.Log("left click.");
        }

        if (Input.GetMouseButtonDown(1)) // right
        {
            Debug.Log("right click.");
        }

        if (Input.GetMouseButtonDown(2)) // middle
        {
            Debug.Log("middle click.");
        }
    }

    void InitModules()
    {
        EventManager.Init();
        Tween.Init();
        BehaviorManager.Init();
    }

    void DoLogic()
    {
        AssetBundle.LoadFromFile("Prefabs/Character");
        OnHeroSpawn();
        //OnMonsterSpawn();
    }

    void OnHeroSpawn()
    {
        int count = 2;
        for (int i = 0; i < count; i++)
        {
            GameObject hero = new GameObject(); // GameObject.Instantiate<GameObject>(Character);
            hero.name = "hero" + i.ToString();
            var agent = hero.GetComponent<Agent>();
            character.SetBehavior();
        }
    }
}
