using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBehaviorTree;


public class ChangeTextColor : MonoBehaviour {

	void Start ()
    {
        // behaviors
        var text = gameObject.GetComponent<Text>();
        agent = new TextAgent(text);
        blackboard = new Blackboard();
        debug = new Debugger();

        var root = new MemSequence(new BaseNode[] {
            new Wait(500),
            new ChangeColor(Color.blue),
            new ChangeColor(Color.red),
        });
        behaviorTree = new BehaviorTree(root);
    }
	
	void Update ()
    {
        debug.Log(index.ToString());
        behaviorTree.tick(agent, blackboard, debug);
        index++;
    }

    public int index = 0;
    public TextAgent agent;
    public Blackboard blackboard;
    public Debugger debug;
    public BehaviorTree behaviorTree;
}
