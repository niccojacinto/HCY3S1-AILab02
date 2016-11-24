using UnityEngine;
using System.Collections;

public class Action : Decision {

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
