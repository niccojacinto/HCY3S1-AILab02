using UnityEngine;
using System.Collections;

public class Action : DecisionTreeNode {

    protected string actionName;
    protected Character character;

    protected Action(Character _character) {
        character = _character;
    }

    // hy
    public bool activated = false;

    public override DecisionTreeNode MakeDecision()
    {
        return this;
    }

    public virtual void LateUpdate()
    {
        if (!activated)
            return;
        // implement behaviours here
    }
}
