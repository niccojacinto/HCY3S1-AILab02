using UnityEngine;
using System.Collections;

public class Decision : DecisionTreeNode {

    public DecisionTreeNode nodeTrue;
    public DecisionTreeNode nodeFalse;

    public override DecisionTreeNode MakeDecision()
    {
        return GetBranch();
    }

    public virtual DecisionTreeNode GetBranch()
    {
        return null;
    }
}
