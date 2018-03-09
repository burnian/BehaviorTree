using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBehaviorTree;
using UnityEngine.UI;


public class TextAgent : Agent
{
    public TextAgent(Text text)
    {
        this.text = text;
    }

    public override void SetColor(object color)
    {
        text.color = (Color)color;
    }

    public override void SetPosition(object pos)
    {
        text.transform.localPosition = (Vector3)pos;
    }


    public Text text;
}
