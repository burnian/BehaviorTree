//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using IBehaviorTree;


//public class ChangeTextColor : MonoBehaviour {

//	void Start ()
//    {
//        // behaviors
//        blackboard = new Blackboard();
//        debug = new Debugger();
//        debug.EnableLog(enableDebug);

//        var root = new MemSequence(new BaseNode[] {
//            new Wait(500),
//            new PlayAnimation("Move"),
//            new Wait(500),
//            new PlayAnimation("Cheers"),
//            new Wait(500),
//            new PlayAnimation("Jump"),
//        });
//        behaviorTree = new BehaviorTree(root);
//    }
	
//	void Update ()
//    {
//        debug.Log(_index.ToString());
//        behaviorTree.tick(gameObject, blackboard, debug);
//        _index++;
//    }

//    //public void OnAnimationEndEvent()
//    //{
//    //    agent.OnAnimationEndEvent();
//    //}


//    int _index = 0;
//    public bool enableDebug = true;
//    public Blackboard blackboard;
//    public Debugger debug;
//    public BehaviorTree behaviorTree;
//}
