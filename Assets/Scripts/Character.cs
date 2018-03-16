using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;


public class Character : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        //debug.Log(_index.ToString());
        //behaviorTree.tick(gameObject, blackboard, debug);
        //_index++;

        if (Input.GetMouseButtonDown(0)) // left
            Debug.Log("left click.");

        if (Input.GetMouseButtonDown(1)) // right
            Debug.Log("right click.");

        if (Input.GetMouseButtonDown(2)) // middle
            Debug.Log("middle click.");
    }

}
