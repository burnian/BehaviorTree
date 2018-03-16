using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBehaviorTree;
using Utils;


public class HeroBehavior
{
    public HeroBehavior()
    {
        // behaviors
        blackboard = new Blackboard();
        debug = new Debugger();
        debug.EnableLog(enableDebug);

        var root = new MemSequence(new BaseNode[] {
            new Wait(5000),
            //new PlayAnimation("move_forward_B"),
            //new Wait(500),
            //new PlayAnimation("move_backward_B"),
        });
        behaviorTree = new BehaviorTree(root);
    }


    public bool enableDebug = true;
    public Blackboard blackboard;
    public Debugger debug;
    public BehaviorTree behaviorTree;
}
