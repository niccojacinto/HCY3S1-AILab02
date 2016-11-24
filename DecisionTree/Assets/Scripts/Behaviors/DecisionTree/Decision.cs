using UnityEngine;
using System.Collections;

public class Decision : DecisionTreeNode {

    public DecisionTreeNode nodeTrue;
    public DecisionTreeNode nodeFalse;

    public bool activated = false;

    public virtual DecisionTreeNode GetBranch()
    {
        return null;
    }
}
